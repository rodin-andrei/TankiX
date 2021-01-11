using System;
using System.Collections;
using Platform.Library.ClientProtocol.API;

namespace Tanks.Battle.ClientCore.Impl
{
	public class MoveCommandCodec : AbstractMoveCodec
	{
		private static readonly int WEAPON_ROTATION_SIZE = 2;

		private static readonly int WEAPON_ROTATION_COMPONENT_BITSIZE = WEAPON_ROTATION_SIZE * 8;

		private static readonly float WEAPON_ROTATION_FACTOR = 360f / (float)(1 << WEAPON_ROTATION_COMPONENT_BITSIZE);

		private static byte[] bufferForWeaponRotation = new byte[WEAPON_ROTATION_SIZE];

		private static byte[] bufferEmpty = new byte[0];

		private static BitArray bitsForWeaponRotation = new BitArray(bufferForWeaponRotation);

		private static BitArray bitsEmpty = new BitArray(bufferEmpty);

		private Codec movementCodec;

		public override void Init(Protocol protocol)
		{
			movementCodec = protocol.GetCodec(typeof(Movement));
		}

		public override void Encode(ProtocolBuffer protocolBuffer, object data)
		{
			base.Encode(protocolBuffer, data);
			MoveCommand moveCommand = (MoveCommand)data;
			bool hasValue = moveCommand.Movement.HasValue;
			bool hasValue2 = moveCommand.WeaponRotation.HasValue;
			bool flag = moveCommand.IsDiscrete();
			protocolBuffer.OptionalMap.Add(hasValue);
			protocolBuffer.OptionalMap.Add(hasValue2);
			protocolBuffer.OptionalMap.Add(flag);
			if (flag)
			{
				DiscreteTankControl discreteTankControl = default(DiscreteTankControl);
				discreteTankControl.MoveAxis = (int)moveCommand.TankControlVertical;
				discreteTankControl.TurnAxis = (int)moveCommand.TankControlHorizontal;
				discreteTankControl.WeaponControl = (int)moveCommand.WeaponRotationControl;
				protocolBuffer.Writer.Write(discreteTankControl.Control);
			}
			else
			{
				protocolBuffer.Writer.Write(moveCommand.TankControlVertical);
				protocolBuffer.Writer.Write(moveCommand.TankControlHorizontal);
				protocolBuffer.Writer.Write(moveCommand.WeaponRotationControl);
			}
			if (hasValue)
			{
				movementCodec.Encode(protocolBuffer, moveCommand.Movement.Value);
			}
			if (hasValue2)
			{
				byte[] buffer = GetBuffer(hasValue2);
				BitArray bits = GetBits(hasValue2);
				int position = 0;
				AbstractMoveCodec.WriteFloat(bits, ref position, moveCommand.WeaponRotation.Value, WEAPON_ROTATION_COMPONENT_BITSIZE, WEAPON_ROTATION_FACTOR);
				bits.CopyTo(buffer, 0);
				protocolBuffer.Writer.Write(buffer);
				if (position != bits.Length)
				{
					throw new Exception("Move command pack mismatch");
				}
			}
			protocolBuffer.Writer.Write(moveCommand.ClientTime);
		}

		public override object Decode(ProtocolBuffer protocolBuffer)
		{
			bool flag = protocolBuffer.OptionalMap.Get();
			bool flag2 = protocolBuffer.OptionalMap.Get();
			bool flag3 = protocolBuffer.OptionalMap.Get();
			MoveCommand moveCommand = default(MoveCommand);
			if (flag3)
			{
				DiscreteTankControl discreteTankControl = default(DiscreteTankControl);
				discreteTankControl.Control = protocolBuffer.Reader.ReadByte();
				moveCommand.TankControlHorizontal = discreteTankControl.TurnAxis;
				moveCommand.TankControlVertical = discreteTankControl.MoveAxis;
				moveCommand.WeaponRotationControl = discreteTankControl.WeaponControl;
			}
			else
			{
				moveCommand.TankControlVertical = protocolBuffer.Reader.ReadSingle();
				moveCommand.TankControlHorizontal = protocolBuffer.Reader.ReadSingle();
				moveCommand.WeaponRotationControl = protocolBuffer.Reader.ReadSingle();
			}
			if (flag)
			{
				moveCommand.Movement = (Movement)movementCodec.Decode(protocolBuffer);
			}
			byte[] buffer = GetBuffer(flag2);
			BitArray bits = GetBits(flag2);
			int position = 0;
			protocolBuffer.Reader.Read(buffer, 0, buffer.Length);
			CopyBits(buffer, bits);
			if (flag2)
			{
				moveCommand.WeaponRotation = AbstractMoveCodec.ReadFloat(bits, ref position, WEAPON_ROTATION_COMPONENT_BITSIZE, WEAPON_ROTATION_FACTOR);
			}
			if (position != bits.Length)
			{
				throw new Exception("Move command unpack mismatch");
			}
			moveCommand.ClientTime = protocolBuffer.Reader.ReadInt32();
			return moveCommand;
		}

		private BitArray GetBits(bool hasWeaponRotation)
		{
			return (!hasWeaponRotation) ? bitsEmpty : bitsForWeaponRotation;
		}

		private byte[] GetBuffer(bool hasWeaponRotation)
		{
			return (!hasWeaponRotation) ? bufferEmpty : bufferForWeaponRotation;
		}
	}
}
