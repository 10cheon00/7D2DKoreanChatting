using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace _7D2DKoreanChatting
{
	[HarmonyPatch]
	public static class KoreanChatting
	{

		[HarmonyPatch(typeof(UIInput), "Update")]
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Update_Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version;
            Log.Out($"7D2DKoreanChatting::Version '{version}'");
            Log.Out($"7D2DKoreanChatting::Start HarmonyTranspiler");
			List<CodeInstruction> source = new List<CodeInstruction>(instructions);
			List<CodeInstruction> codeInstructionList = new List<CodeInstruction>(instructions);
			for (int i = 0; i < codeInstructionList.Count; i++)
			{
				if (codeInstructionList[i].opcode == OpCodes.Ldloc_1)
				{
					for (int j = 0; j < 3; j++)
					{
						Log.Out($"7D2DKoreanChatting::Delete opcode '{codeInstructionList[i + j].opcode.Name}'");
						codeInstructionList[i + j].opcode = OpCodes.Nop;
					}
					break;
				}
			}
			Log.Out($"7D2DKoreanChatting::End HarmonyTranspiler");
			return source.AsEnumerable();
		}
	}
}
