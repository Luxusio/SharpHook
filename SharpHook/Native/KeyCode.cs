namespace SharpHook.Native
{
    /// <summary>
    /// Represents a virtual key code.
    /// </summary>
    /// <seealso cref="KeyboardEventData" />
    public enum KeyCode : ushort
    {
        VcEscape = 0x0001,

        VcF1 = 0x003B,
        VcF2 = 0x003C,
        VcF3 = 0x003D,
        VcF4 = 0x003E,
        VcF5 = 0x003F,
        VcF6 = 0x0040,
        VcF7 = 0x0041,
        VcF8 = 0x0042,
        VcF9 = 0x0043,
        VcF10 = 0x0044,
        VcF11 = 0x0057,
        VcF12 = 0x0058,

        VcF13 = 0x005B,
        VcF14 = 0x005C,
        VcF15 = 0x005D,
        VcF16 = 0x0063,
        VcF17 = 0x0064,
        VcF18 = 0x0065,
        VcF19 = 0x0066,
        VcF20 = 0x0067,
        VcF21 = 0x0068,
        VcF22 = 0x0069,
        VcF23 = 0x006A,
        VcF24 = 0x006B,

        VcBackquote = 0x0029,

        Vc1 = 0x0002,
        Vc2 = 0x0003,
        Vc3 = 0x0004,
        Vc4 = 0x0005,
        Vc5 = 0x0006,
        Vc6 = 0x0007,
        Vc7 = 0x0008,
        Vc8 = 0x0009,
        Vc9 = 0x000A,
        Vc0 = 0x000B,

        VcMinus = 0x000C,
        VcEquals = 0x000D,
        VcBackspace = 0x000E,

        VcTab = 0x000F,
        VcCapsLock = 0x003A,

        VcA = 0x001E,
        VcB = 0x0030,
        VcC = 0x002E,
        VcD = 0x0020,
        VcE = 0x0012,
        VcF = 0x0021,
        VcG = 0x0022,
        VcH = 0x0023,
        VcI = 0x0017,
        VcJ = 0x0024,
        VcK = 0x0025,
        VcL = 0x0026,
        VcM = 0x0032,
        VcN = 0x0031,
        VcO = 0x0018,
        VcP = 0x0019,
        VcQ = 0x0010,
        VcR = 0x0013,
        VcS = 0x001F,
        VcT = 0x0014,
        VcU = 0x0016,
        VcV = 0x002F,
        VcW = 0x0011,
        VcX = 0x002D,
        VcY = 0x0015,
        VcZ = 0x002C,

        VcOpenBracket = 0x001A,
        VcCloseBracket = 0x001B,
        VcBackSlash = 0x002B,

        VcSemicolon = 0x0027,
        VcQuote = 0x0028,
        VcEnter = 0x001C,

        VcComma = 0x0033,
        VcPeriod = 0x0034,
        VcSlash = 0x0035,

        VcSpace = 0x0039,

        VcPrintscreen = 0x0E37,
        VcScrollLock = 0x0046,
        VcPause = 0x0E45,

        VcLesserGreater = 0x0E46,

        VcInsert = 0x0E52,
        VcDelete = 0x0E53,
        VcHome = 0x0E47,
        VcEnd = 0x0E4F,
        VcPageUp = 0x0E49,
        VcPageDown = 0x0E51,

        VcUp = 0xE048,
        VcLeft = 0xE04B,
        VcClear = 0xE04C,
        VcRight = 0xE04D,
        VcDown = 0xE050,

        VcNumLock = 0x0045,
        VcNumPadDivide = 0x0E35,
        VcNumPadMultiply = 0x0037,
        VcNumPadSubtract = 0x004A,
        VcNumPadEquals = 0x0E0D,
        VcNumPadAdd = 0x004E,
        VcNumPadEnter = 0x0E1C,
        VcNumPadSeparator = 0x0053,

        VcNumPad1 = 0x004F,
        VcNumPad2 = 0x0050,
        VcNumPad3 = 0x0051,
        VcNumPad4 = 0x004B,
        VcNumPad5 = 0x004C,
        VcNumPad6 = 0x004D,
        VcNumPad7 = 0x0047,
        VcNumPad8 = 0x0048,
        VcNumPad9 = 0x0049,
        VcNumPad0 = 0x0052,

        VcNumPadEnd = 0xEE00 | VcNumPad1,
        VcNumPadDown = 0xEE00 | VcNumPad2,
        VcNumPadPageDown = 0xEE00 | VcNumPad3,
        VcNumPadLeft = 0xEE00 | VcNumPad4,
        VcNumPadClear = 0xEE00 | VcNumPad5,
        VcNumPadRight = 0xEE00 | VcNumPad6,
        VcNumPadHome = 0xEE00 | VcNumPad7,
        VcNumPadUp = 0xEE00 | VcNumPad8,
        VcNumPadPageUp = 0xEE00 | VcNumPad9,
        VcNumPadInsert = 0xEE00 | VcNumPad0,
        VcNumPadDelete = 0xEE00 | VcNumPadSeparator,

        VcLeftShift = 0x002A,
        VcRightShift = 0x0036,
        VcLeftControl = 0x001D,
        VcRightControl = 0x0E1D,
        VcLeftAlt = 0x0038,
        VcRightAlt = 0x0E38,
        VcLeftMeta = 0x0E5B,
        VcRightMeta = 0x0E5C,
        VcContextMenu = 0x0E5D,

        VcPower = 0xE05E,
        VcSleep = 0xE05F,
        VcWake = 0xE063,

        VcMediaPlay = 0xE022,
        VcMediaStop = 0xE024,
        VcMediaPrevious = 0xE010,
        VcMediaNext = 0xE019,
        VcMediaSelect = 0xE06D,
        VcMediaEject = 0xE02C,

        VcVolumeMute = 0xE020,
        VcVolumeUp = 0xE030,
        VcVolumeDown = 0xE02E,

        VcAppMail = 0xE06C,
        VcAppCalculator = 0xE021,
        VcAppMusic = 0xE03C,
        VcAppPictures = 0xE064,

        VcBrowserSearch = 0xE065,
        VcBrowserHome = 0xE032,
        VcBrowserBack = 0xE06A,
        VcBrowserForward = 0xE069,
        VcBrowserStop = 0xE068,
        VcBrowserRefresh = 0xE067,
        VcBrowserFavorites = 0xE066,

        VcKatakana = 0x0070,
        VcUnderscore = 0x0073,
        VcFurigana = 0x0077,
        VcKanji = 0x0079,
        VcHiragana = 0x007B,
        VcYen = 0x007D,
        VcNumPadComma = 0x007E,

        VcSunHelp = 0xFF75,

        VcSunStop = 0xFF78,
        VcSunProps = 0xFF76,
        VcSunFront = 0xFF77,
        VcSunOpen = 0xFF74,
        VcSunFind = 0xFF7E,
        VcSunAgain = 0xFF79,
        VcSunUndo = 0xFF7A,
        VcSunCopy = 0xFF7C,
        VcSunInsert = 0xFF7D,
        VcSunCut = 0xFF7B,

        VcUndefined = 0x0000,
        CharUndefined = 0xFFFF
    }
}
