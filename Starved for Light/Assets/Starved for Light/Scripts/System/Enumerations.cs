namespace S4L.Enums {

    /* Inputs summary:
     * 
     * Float: movement axis
     * Hold : Gallop
     * Hold / tap: Jump
     * Climb edge (Hold W / Up stick)
     * Hold: Light spells
     * Hold: Sneak
     * Hold: Crawl/Dodge
     * Tap: Dream Protector spell
     * Tap / Hold: Interact
     */

    public enum PlayerButtonInput {
        //Menus
        Submit,
        Cancel,

        //Gameplay
        Jump,
        Gallop,
        //CrawlDodge,
        //Sneak,
        //Interact
    }

    public enum PlayerAxisInput {
        Horizontal,
        Vertical,
        LookHorizontal,
        LookVertical,
    }

    public enum ButtonEvent {
        Down,
        Hold,
        Up
    }
}