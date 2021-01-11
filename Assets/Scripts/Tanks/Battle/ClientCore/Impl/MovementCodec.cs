using System;
using System.Collections;
using Platform.Library.ClientProtocol.API;
using UnityEngine;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MovementCodec : AbstractMoveCodec
	{
		private static readonly int MOVEMENT_SIZE = 21;

		private static readonly int POSITION_COMPONENT_BITSIZE = 17;

		private static readonly int ORIENTATION_COMPONENT_BITSIZE = 13;

		private static readonly int LINEAR_VELOCITY_COMPONENT_BITSIZE = 13;

		private static readonly int ANGULAR_VELOCITY_COMPONENT_BITSIZE = 13;

		private static readonly float POSITION_FACTOR = 0.01f;

		private static readonly float VELOCITY_FACTOR = 0.01f;

		private static readonly float ANGULAR_VELOCITY_FACTOR = 0.005f;

		private static readonly float ORIENTATION_PRECISION = 2f / (float)(1 << ORIENTATION_COMPONENT_BITSIZE);

		public override void Init(Protocol protocol)
		{
		}

		public override void Encode(ProtocolBuffer protocolBuffer, object data)
		{
			base.Encode(protocolBuffer, data);
			Movement movement = (Movement)data;
			byte[] array = new byte[MOVEMENT_SIZE];
			BitArray bitArray = new BitArray(array);
			int position = 0;
			WriteVector3(bitArray, ref position, movement.Position, POSITION_COMPONENT_BITSIZE, POSITION_FACTOR);
			WriteQuaternion(bitArray, ref position, movement.Orientation, ORIENTATION_COMPONENT_BITSIZE, ORIENTATION_PRECISION);
			WriteVector3(bitArray, ref position, movement.Velocity, LINEAR_VELOCITY_COMPONENT_BITSIZE, VELOCITY_FACTOR);
			WriteVector3(bitArray, ref position, movement.AngularVelocity, ANGULAR_VELOCITY_COMPONENT_BITSIZE, ANGULAR_VELOCITY_FACTOR);
			bitArray.CopyTo(array, 0);
			protocolBuffer.Writer.Write(array);
			if (position != bitArray.Length)
			{
				throw new Exception("Movement pack mismatch");
			}
		}

		public override object Decode(ProtocolBuffer protocolBuffer)
		{
			Movement movement = default(Movement);
			byte[] array = new byte[MOVEMENT_SIZE];
			BitArray bitArray = new BitArray(array);
			int position = 0;
			protocolBuffer.Reader.Read(array, 0, array.Length);
			CopyBits(array, bitArray);
			movement.Position = ReadVector3(bitArray, ref position, POSITION_COMPONENT_BITSIZE, POSITION_FACTOR);
			movement.Orientation = ReadQuaternion(bitArray, ref position, ORIENTATION_COMPONENT_BITSIZE, ORIENTATION_PRECISION);
			movement.Velocity = ReadVector3(bitArray, ref position, LINEAR_VELOCITY_COMPONENT_BITSIZE, VELOCITY_FACTOR);
			movement.AngularVelocity = ReadVector3(bitArray, ref position, ANGULAR_VELOCITY_COMPONENT_BITSIZE, ANGULAR_VELOCITY_FACTOR);
			if (position != bitArray.Length)
			{
				throw new Exception("Movement unpack mismatch");
			}
			return movement;
		}

		private static Vector3 ReadVector3(BitArray bits, ref int position, int size, float factor)
		{
			Vector3 result = default(Vector3);
			result.x = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			result.y = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			result.z = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			return result;
		}

		private static Quaternion ReadQuaternion(BitArray bits, ref int position, int size, float factor)
		{
			Quaternion result = default(Quaternion);
			result.x = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			result.y = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			result.z = AbstractMoveCodec.ReadFloat(bits, ref position, size, factor);
			result.w = Mathf.Sqrt(1f - (result.x * result.x + result.y * result.y + result.z * result.z));
			if (double.IsNaN(result.w))
			{
				result.w = 0f;
			}
			return result;
		}

		private static void WriteVector3(BitArray bits, ref int position, Vector3 value, int size, float factor)
		{
			AbstractMoveCodec.WriteFloat(bits, ref position, value.x, size, factor);
			AbstractMoveCodec.WriteFloat(bits, ref position, value.y, size, factor);
			AbstractMoveCodec.WriteFloat(bits, ref position, value.z, size, factor);
		}

		private static void WriteQuaternion(BitArray bits, ref int position, Quaternion value, int size, float factor)
		{
			int num = ((value.w >= 0f) ? 1 : (-1));
			AbstractMoveCodec.WriteFloat(bits, ref position, value.x * (float)num, size, factor);
			AbstractMoveCodec.WriteFloat(bits, ref position, value.y * (float)num, size, factor);
			AbstractMoveCodec.WriteFloat(bits, ref position, value.z * (float)num, size, factor);
		}
	}
}
