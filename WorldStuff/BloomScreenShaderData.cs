using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace Emperia.WorldStuff
{
	public class BloomScreenShaderData : ScreenShaderData
	{
		bool b = false;
		public BloomScreenShaderData(string passName)
			: base(passName)
		{
		}
		
		public override void Apply()
		{
			if (b)
			base.Apply();
		}
	}
}