using System;
using System.Collections.Generic;
using System.IO;

namespace Platform.Library.ClientResources.API
{
	public class FileBackupTransaction : IDisposable
	{
		private interface Task
		{
			Task Run();

			void Rollback();

			void Commit();
		}

		private class DeleteTask : Task
		{
			private string path;

			private string backupPath;

			public DeleteTask(string path)
			{
				this.path = path;
				backupPath = string.Format("{0}.bck", path);
			}

			public Task Run()
			{
				File.SetAttributes(path, FileAttributes.Archive);
				if (File.Exists(backupPath))
				{
					File.SetAttributes(backupPath, FileAttributes.Archive);
					File.Delete(backupPath);
				}
				File.Copy(path, backupPath);
				File.Delete(path);
				return this;
			}

			public void Rollback()
			{
				if (File.Exists(path))
				{
					File.SetAttributes(path, FileAttributes.Archive);
					File.Delete(path);
				}
				File.Copy(backupPath, path);
				File.SetAttributes(backupPath, FileAttributes.Archive);
				File.Delete(backupPath);
			}

			public void Commit()
			{
				File.SetAttributes(backupPath, FileAttributes.Archive);
				File.Delete(backupPath);
			}
		}

		private class CopyTask : Task
		{
			private string formPath;

			private string toPath;

			public CopyTask(string formPath, string toPath)
			{
				this.formPath = formPath;
				this.toPath = toPath;
			}

			public Task Run()
			{
				File.Copy(formPath, toPath);
				return this;
			}

			public void Rollback()
			{
				if (File.Exists(toPath))
				{
					File.SetAttributes(toPath, FileAttributes.Archive);
					File.Delete(toPath);
				}
			}

			public void Commit()
			{
			}
		}

		private Stack<Task> history = new Stack<Task>();

		public void DeleteFile(string path)
		{
			DeleteTask deleteTask = new DeleteTask(path);
			deleteTask.Run();
			history.Push(deleteTask);
		}

		public void CopyFile(string fromPath, string toPath)
		{
			CopyTask copyTask = new CopyTask(fromPath, toPath);
			copyTask.Run();
			history.Push(copyTask);
		}

		public void ReplaceFile(string fromPath, string toPath)
		{
			if (File.Exists(toPath))
			{
				DeleteFile(toPath);
			}
			else
			{
				string directoryName = Path.GetDirectoryName(toPath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
			}
			CopyFile(fromPath, toPath);
		}

		public void Commit()
		{
			while (history.Count > 0)
			{
				try
				{
					history.Pop().Commit();
				}
				catch
				{
					history.Clear();
					throw;
				}
			}
		}

		public void Rollback()
		{
			while (history.Count > 0)
			{
				history.Pop().Rollback();
			}
		}

		public void Dispose()
		{
			Rollback();
		}
	}
}
