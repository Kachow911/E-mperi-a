using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Emperia
{
	public class Emperia : Mod
	{
		public Emperia()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
		}


	}
}