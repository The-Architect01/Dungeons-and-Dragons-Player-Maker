﻿using System.Reflection;

namespace Dungeons_and_Dragons_Player_Maker.Player_Maker {
    public struct ImageLocation {
        //All Images are from D&D Beyond
#pragma warning disable IDE0051 // Remove unused private members
        #region RACES
        private static readonly string DRAGONBORN = "https://www.dndbeyond.com/avatars/thumbnails/6/340/420/618/636272677995471928.png";
        private static readonly string DWARF = "https://www.dndbeyond.com/avatars/thumbnails/6/254/420/618/636271781394265550.png";
        private static readonly string ELF = "https://www.dndbeyond.com/avatars/thumbnails/7/639/420/618/636287075350739045.png";
        private static readonly string ELF_DROW = "http://media-waterdeep.cursecdn.com/attachments/0/620/elf.png";
        private static readonly string ELF_ELADRIN = "https://www.dndbeyond.com/attachments/thumbnails/3/907/300/494/spring-eladrin.png";
        private static readonly string ELF_HIGH = "https://www.dndbeyond.com/avatars/thumbnails/7/639/420/618/636287075350739045.png";
        private static readonly string GNOME = "https://www.dndbeyond.com/avatars/thumbnails/6/334/420/618/636272671553055253.png";
        private static readonly string HALF_ELF = "https://www.dndbeyond.com/avatars/thumbnails/6/481/420/618/636274618102950794.png";
        private static readonly string HALFLING = "https://www.dndbeyond.com/avatars/thumbnails/6/256/420/618/636271789409776659.png";
        private static readonly string HALF_ORC = "https://www.dndbeyond.com/avatars/thumbnails/6/466/420/618/636274570630462055.png";
        private static readonly string HUMAN = "https://www.dndbeyond.com/avatars/thumbnails/6/258/420/618/636271801914013762.png";
        private static readonly string TIEFLING = "https://www.dndbeyond.com/avatars/thumbnails/7/641/420/618/636287076637981942.png";
        #endregion
        #region CLASSES
        private static readonly string ARTIFICER = "https://www.dndbeyond.com/attachments/thumbnails/7/107/350/435/1-39.png";
        private static readonly string BARBARIAN = "https://www.dndbeyond.com/avatars/thumbnails/6/342/420/618/636272680339895080.png";
        private static readonly string BARD = "https://www.dndbeyond.com/avatars/thumbnails/6/369/420/618/636272705936709430.png";
        private static readonly string BLOOD_HUNTER = "https://www.dndbeyond.com/avatars/thumbnails/8551/968/420/618/637158853099606981.png";
        private static readonly string CLERIC = "https://www.dndbeyond.com/avatars/thumbnails/6/371/420/618/636272706155064423.png";
        private static readonly string DRUID = "https://www.dndbeyond.com/avatars/thumbnails/6/346/420/618/636272691461725405.png";
        private static readonly string FIGHTER = "https://www.dndbeyond.com/avatars/thumbnails/6/359/420/618/636272697874197438.png";
        private static readonly string MONK = "https://www.dndbeyond.com/avatars/thumbnails/6/489/420/618/636274646181411106.png";
        private static readonly string PALADIN = "https://www.dndbeyond.com/avatars/thumbnails/6/365/420/618/636272701937419552.png";
        private static readonly string RANGER = "https://www.dndbeyond.com/avatars/thumbnails/6/367/420/618/636272702826438096.png";
        private static readonly string ROGUE = "https://www.dndbeyond.com/avatars/thumbnails/6/384/420/618/636272820319276620.png";
        private static readonly string SORCERER = "https://www.dndbeyond.com/avatars/thumbnails/6/485/420/618/636274643818663058.png";
        private static readonly string WARLOCK = "https://www.dndbeyond.com/avatars/thumbnails/6/375/420/618/636272708661726603.png";
        private static readonly string WIZARD = "https://www.dndbeyond.com/avatars/thumbnails/6/357/420/618/636272696881281556.png";
        #endregion
        private static readonly string SHEET = "https://imgv2-2-f.scribdassets.com/img/document/234991403/original/cc9da91721/1634041659?v5";//"https://content.instructables.com/ORIG/F32/Y0FV/J8F5Q3W5/F32Y0FVJ8F5Q3W5.png";
        private static readonly string SPLASH =
            (System.DateTime.Now.Month == 10 ?
            //Spooky Season
            "https://images.ctfassets.net/swt2dsco9mfe/3a0LIPmT0YfHDP7xhcUaYS/b1c6ad2606983c4b9374ce4e1602eb46/dnd_vpw_othermedia.jpg" :
            //PHB
            //"https://images.ctfassets.net/swt2dsco9mfe/5j4I9MGSt44T67nDoQuEk7/0a1bd4e9b0814e1bb6df92cf793e53a1/rJGxllAtvbBhYnO.hero.jpg"
            //BETA Test
            //"https://media.dnd.wizards.com/images/video/starterset_th.jpg"
            //Unearth Arcana/BETA
            "https://images.ctfassets.net/swt2dsco9mfe/1hbWSrCP99lgc8xpGHKfUh/26cce9379bc6f9feeff4466b414d22f4/312912_1023x550.jpg"
            //Fizban
            //"https://images.ctfassets.net/swt2dsco9mfe/6tsR29Slg89AshLq5dmd2U/14daf5a0f02bf0e248fe8bfe75b0d103/qhxIu1bYe2ci1cwelc.jpg"
            //???
            //"https://images.ctfassets.net/swt2dsco9mfe/3Nbjd1gA4LbFYePeoeRryb/9b6079312cf03e4f939dada20ecb577a/stay-play-home1920x1342.jpg"
            );
#pragma warning restore IDE0051 // Remove unused private members

        public static string GetImage(string request) {
            return (string) typeof(ImageLocation).GetField(request.ToUpper().Replace(" ","_").Replace("-","_").ToString(),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).GetValue(typeof(ImageLocation));
        }
    }
}
