using System;
using UnityEngine;
using Verse.AI;

namespace Verse
{
    internal class DwarfPawn : Pawn
    {
        public DwarfPawn() : base() {
        }

        public static Graphic_Apparel DwarfGraphic = new Graphic_Apparel("Things/Pawn/Dwarf/Dwarf", new Color(1, 1, 1));
        public static Graphic_Apparel DwarfMilitiaGraphic = new Graphic_Apparel("Things/Pawn/Dwarf/Dwarf_Militia", new Color(1, 1, 1));

        public override void Tick()
        {
            if (this.IsColonist && this.drawer != null && this.drawer.renderer != null && this.drawer.renderer.graphics != null)
            {
                this.drawer.renderer.graphics.headGraphic = null;
                this.apparel = null;

                if (this.playerController.Drafted) {
                    this.drawer.renderer.graphics.nakedGraphic = DwarfMilitiaGraphic;
                } else {
                    this.drawer.renderer.graphics.nakedGraphic = DwarfGraphic;
                }
            }

            base.Tick();
        }
    }
}
