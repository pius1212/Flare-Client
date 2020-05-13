﻿using Flare_Remastered.Client.Categories;
using Flare_Remastered.Client.Keybinds;
using Flare_Remastered.SparkSDK;

namespace Flare_Remastered.Client.Modules.Modules
{
    public class Jetpack : Module
    {
        public Jetpack() : base("Jetpack", CategoryHandler.registry.categories[1], 'F', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
            RegisterFloatSliderSetting("Jetpack", 0F, 1F, 20F);
        }
        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind)
            {
                enabled = false;
            }
        }
        public override void onTick()
        {
            base.onTick();
            Utils.Vec3f directionalVec = Minecraft.clientInstance.localPlayer.lookingVec;
            Minecraft.clientInstance.localPlayer.velX = sliderFloatSettings[0].value * directionalVec.x;
            Minecraft.clientInstance.localPlayer.velY = sliderFloatSettings[0].value * -directionalVec.y;
            Minecraft.clientInstance.localPlayer.velZ = sliderFloatSettings[0].value * directionalVec.z;
        }
    }
}
