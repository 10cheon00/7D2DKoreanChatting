using HarmonyLib;
using System.Reflection;

namespace UnlimitedParty
{
	public class Main : IModApi
	{
		public Main Instance;
		public const string PLUGIN_GUID = "com.10cheon00.7d2d.7d2d-korean-chatting";
		public Harmony harmony;

		public void InitMod(Mod _modInstance)
		{
			this.Instance = this;
			this.harmony = new Harmony(this.GetType().ToString());
			this.harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
