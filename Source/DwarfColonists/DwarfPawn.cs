using System;
using UnityEngine;
using Verse.AI;

namespace Verse
{
    internal class DwarfPawn : Pawn
    {

        public static Graphic_Apparel DwarfGraphic = new Graphic_Apparel("Things/Pawn/Dwarf/Dwarf", new Color(1, 1, 1));
        public static Graphic_Apparel DwarfMilitiaGraphic = new Graphic_Apparel("Things/Pawn/Dwarf/Dwarf_Militia", new Color(1, 1, 1));        

        private bool dwarfReady = false;
        private bool dwarfDrafted = false;

        public DwarfPawn() : base() {
        }

        public void DwarfSetup() {
            if (!this.IsColonist || this.drawer == null || this.drawer.renderer == null || this.drawer.renderer.graphics == null) {
                return;
            }

            this.drawer.renderer.graphics.headGraphic = null;

            var apparel = (Apparel)ThingMaker.MakeThing(ThingDef.Named("Apparel_BasicShirt"));
            
            if (this.playerController.Drafted) {
                this.drawer.renderer.graphics.nakedGraphic = DwarfMilitiaGraphic;
                apparel.graphic = DwarfMilitiaGraphic;
                this.dwarfDrafted = true;
            } else {
                this.drawer.renderer.graphics.nakedGraphic = DwarfGraphic;
                apparel.graphic = DwarfGraphic;
                this.dwarfDrafted = false;
            }

            this.apparel.SetApparel(apparel);
            this.dwarfReady = true;
        }

        public override void Tick()
        {
            if (!this.dwarfReady || this.playerController.Drafted != this.dwarfDrafted) {
                DwarfSetup();
            }

            base.Tick();
        }
    }
}
