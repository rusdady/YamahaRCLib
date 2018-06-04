using YamahaAVLib.Attributes;

namespace YamahaAVLib.ENums
{
    public enum FunctionType
    {

        #region <Menu Func="Unit" Title_1="System" YNC_Tag="System">
        /// <summary>
        /// Option allows turn on or off event notifications. 
        /// Method SetStatusOf accepts "On" or "Off" values.
        /// Method GetStatusOf returns "On" or "Off" values.
        /// </summary>
        [Device("Unit")]
        [Func("Event")]
        SysEvent,

        /// <summary>
        /// Option allows to check if firmware update available.
        /// Only method GetStatusOf available.
        /// Method GetStatusOf returns "Available" or "Unavailable" values.
        /// </summary>
        [Device("Unit")]
        [Func("Update_Status")]
        SysUpdateAvailable,

        /// <summary>
        /// Option allows update network name of a receiver.
        /// Method SetStatusOf accepts network name upto 15 characters long in UTF-8.
        /// Method GetStatusOf returns network name of a receiver.
        /// </summary>
        [Device("Unit")]
        [Func("Rename")]
        SysNetworkName,

        /// <summary>
        /// Option allows turn on or off power. 
        /// Only method SetStatusOf available.
        /// Method SetStatusOf accepts "On" or "Standby" values.
        /// </summary>
        [Device("Unit")]
        [Func("Power")]
        SysPowerStatus,

        /// <summary>
        /// Option allows turn on or off network standby mode. 
        /// Method SetStatusOf accepts "On" or "Off" values.
        /// Method GetStatusOf returns "On" or "Off" values.
        /// </summary>
        [Device("Unit")]
        [Func("Net_Standby")]
        SysNetworkStandby,

        /// <summary>
        /// Option allows turn enables or disables DMC function. 
        /// Method SetStatusOf accepts "Disable" or "Enable" values.
        /// Method GetStatusOf returns "Disable" or "Enable" values.
        /// </summary>
        [Device("Unit")]
        [FuncEx("DMR")]
        SysDMCControl,
        #endregion

        #region <Menu Func="Subunit" Title_1="Main Zone" YNC_Tag="Main_Zone">

        /// <summary>
        /// Option allows to get status of selected input or select Input.
        /// Method SetStatusOf accepts values saved in SelectionList after calling GetStatusOf method with this option.
        /// </summary>
        [Device("Subunit")]
        //[Func("Input")]
        [FuncEx("Input")]
        SubunitInput,

        /// <summary>
        /// Option allows to get status of selected input or select Scene.
        /// Method SetStatusOf accepts values saved in SelectionList after calling GetStatusOf method with this option.
        /// </summary>
        [Device("Subunit")]
        //[Func("Input")]
        [FuncEx("Scene")]
        SubunitScene,

        /// <summary>
        /// Option allows to change Volume level.
        /// Value must be in range between -805 and 165 with step 5.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Vol")]
        [Func("Vol_Lvl")]
        SubunitVolumeLevel,

        /// <summary>
        /// Option allows turn on or off mute function. 
        /// Method SetStatusOf accepts "On" or "Off" values.
        /// Method GetStatusOf returns "On" or "Off" values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Vol")]
        [Func("Vol_Mute")]
        SubunitVolumeMute,

        /// <summary>
        /// Option allows turn on or off power. 
        /// Method GetStatusOf returns "On" or "Standby" values.
        /// Method SetStatusOf accepts "On" or "Standby" values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Power_Control")]
        [Func("Power")]
        SubunitPowerControlPower,

        /// <summary>
        /// Option allows set sleep delay. 
        /// Method GetStatusOf returns "Off","30 min","60 min","90 min","120 min", "Last" values.
        /// Method SetStatusOf accepts "Off","30 min","60 min","90 min","120 min", "Last" values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Power_Control")]
        [Func("Sleep")]
        SubunitPowerControlSleep,

        /// <summary>
        /// Option allows turn on or off power. 
        /// Method GetStatusOf returns "Play", "Pause", "Stop" values.
        /// Method SetStatusOf accepts "Play", "Pause", "Stop" values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        SubunitPlayControlPlayback,

        /// <summary>
        /// Option allows select next track or previos one. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts "Skip Fwd", "Skip Rev" values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        SubunitPlayControlPlusMinus,

        /// <summary>
        /// Option allows cursor movements. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts Up,Down,Left,Left,Right,Return,Sel,Return to Home,On Screen,Option,Display values.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("List_Control")]
        [Func("Cursor")]
        SubunitListControlCursor,

        /// <summary>
        /// Option allows to change Surround sound program.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values:
        /// Hall in Munich,Hall in Vienna,Chamber,Cellar Club,The Roxy Theatre,The Bottom Line,Sports,Action Game,
        /// Roleplaying Game, Music Video, Standard, Spectacle, Sci-Fi, Adventure, Drama, Mono Movie, Surround Decoder,2ch Stereo,7ch Stereo
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Func_Ex", "Surround")]
        [FuncEx("Program")]
        SubunitSurroundProgram,

        /// <summary>
        /// Option allows set Straight mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: On, Off.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Func_Ex", "Surround")]
        [FuncEx("Straight")]
        SubunitSurroundStraight,

        /// <summary>
        /// Option allows set Enhancer mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: On, Off.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Func_Ex", "Surround")]
        [FuncEx("Enhancer")]
        SubunitSurroundEnhancer,

        /// <summary>
        /// Option allows to change Bass tone level.
        /// Value must be in range between -60 and 60 with step 5.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Tone")]
        [Func("Bass")]
        SubunitBass,

        /// <summary>
        /// Option allows to change Treble tone level.
        /// Value must be in range between -60 and 60 with step 5.
        /// </summary>
        [Device("Subunit")]
        [ParentFunc("Tone")]
        [Func("Treble")]
        SubunitTreble,

        /// <summary>
        /// Option allows set Adaptive DRC mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: Auto, Off.
        /// </summary>
        [Device("Subunit")]
        [FuncEx("Adaptive_DRC")]
        SubunitAdaptiveDRC,

        /// <summary>
        /// Option allows set CINEMA 3D DSP mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: Auto, Off.
        /// </summary>
        [Device("Subunit")]
        [FuncEx("CINEMA_DSP_3D")]
        SubunitCinemaDSP3D,

        /// <summary>
        /// Option allows set Direct mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: On, Off.
        /// </summary>
        [Device("Subunit")]
        [FuncEx("Direct")]
        SubunitDirect,

        /// <summary>
        /// Option allows set HDMI Through While In Standby mode on or off.
        /// Methods GetStatusOf and SetStatusOf accepts and returns following values: On, Off.
        /// </summary>
        [Device("Subunit")]
        [FuncEx("HDMI_Standby_Through")]
        SubunitHDMIStandbyThrough,

        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_Tuner" YNC_Tag="Tuner">

        /// <summary>
        /// Option allows to check if Tuner device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [Func("Status")]
        TunerStatus,

        /// <summary>
        /// Option allows autoscan control of AM band of radio tuner.
        /// Method SetStatusOf accepts values Auto Up,Auto Down,Cancel. 
        /// method GetStatusOf returns Auto Up,Auto Down values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        [FuncEx("Freq_AM")]
        TunerPlayControlPlusMinusAM,

        /// <summary>
        /// Option allows autoscan control of FM band of radio tuner.
        /// Method SetStatusOf accepts values Auto Up,Auto Down,Cancel. 
        /// method GetStatusOf returns Auto Up,Auto Down values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        [FuncEx("Freq_FM")]
        TunerPlayControlPlusMinusFM,

        /// <summary>
        /// Option allows go step up or step down in preset.
        /// Method SetStatusOf accepts Up, Down values.
        /// Method GetStatusOf saves preset list in SelectionList.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        [FuncEx("Preset")]
        TunerPlayControlPreset,

        /// <summary>
        /// Option allows switching between AM and FM bands. 
        /// Method SetStatusOf accepts "AM" or "FM" values.
        /// Method GetStatusOf returns "AM" or "FM" values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Band")]
        TunerBand,

        /// <summary>
        /// Option allows manual control of AM band of radio tuner.
        /// Method SetStatusOf accepts values Auto Up,Auto Down,Cancel. 
        /// Acceptable range between 530 and 1710 kHz with step 10 kHz.
        /// method GetStatusOf returns Auto Up,Auto Down values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Freq")]
        [FuncEx("Freq_AM")]
        TunerPlayControlFrequencyAM,

        /// <summary>
        /// Option allows manual control of FM band of radio tuner.
        /// Method SetStatusOf accepts values Auto Up,Auto Down,Cancel. 
        /// Acceptable range between 8750 and 10790 kHz with step 20 kHz.
        /// method GetStatusOf returns Auto Up,Auto Down values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Freq")]
        [FuncEx("Freq_FM")]
        TunerPlayControlFrequencyFM,

        /// <summary>
        /// Option allows go step up or step down in preset.
        /// Method SetStatusOf accepts Up, Down values.
        /// Method GetStatusOf saves preset list in SelectionList.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Control")]
        [Func("Preset")]
        [FuncEx("Preset")]
        TunerPlayControlPresetControl,

        /// <summary>
        /// Options provides tuner band info.
        /// Only GetStatusOf method available.
        /// Returns AM,FM values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Info")]
        [Func("Band")]
        TunerPlayInfoBand,

        /// <summary>
        /// Options provides tuner frequency info.
        /// Only GetStatusOf method available.
        /// Returns frequency values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Info")]
        [Func("Freq")]
        [FuncEx("Freq_AM_FM")]
        TunerPlayInfoFrequency,

        /// <summary>
        /// Options provides tuner signal tuning info.
        /// Only GetStatusOf method available.
        /// Returns Negate,Assert values.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Info")]
        [FuncEx("Tuned")]
        TunerPlayInfoStatusTuned,

        /// <summary>
        /// Options provides tuner signal stereo/mono info.
        /// Only GetStatusOf method available.
        /// Returns Negate,Assert values.
        /// Negate=>Mono, Assert=>Stereo.
        /// </summary>
        [Device("Func_Ex", "SD_Tuner")]
        [ParentFunc("Play_Info")]
        [FuncEx("Stereo")]
        TunerPlayInfoStatusStereo,
        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_AirPlay" YNC_Tag="AirPlay">

        /// <summary>
        /// Option allows to check if AirPlay device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [Func("Status")]
        AirPlayStatus,

        /// <summary>
        /// Option allows autoscan control of AM band of radio tuner.
        /// Method SetStatusOf accepts values Play, Pause. 
        /// Method GetStatusOf returns Play, Stop values.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        AirPlayPlayControlPlayback,

        /// <summary>
        /// Option allows select next track or previos one. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts "Skip Fwd", "Skip Rev" values.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        AirPlayPlayControlPlusMinus,

        /// <summary>
        /// Option provides info about artist.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Artist")]
        AirPlayPlayInfoArtist,

        /// <summary>
        /// Option provides info about album.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Album")]
        AirPlayPlayInfoAlbum,

        /// <summary>
        /// Option provides info about song.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Song")]
        AirPlayPlayInfoSong,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Status")]
        AirPlayPlayInfoStatus,

        /// <summary>
        /// Option provides info about playback status.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns Play or Stop values.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Playback")]
        AirPlayPlayInfoPlayback,

        /// <summary>
        /// Option provides info about logo.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_AirPlay")]
        [ParentFunc("Play_Info")]
        [Func("Input_Logo_URL")]
        AirPlayPlayInfoInputLogoURL,
        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_iPod_USB" YNC_Tag="iPod_USB">

        /// <summary>
        /// Option initialzes iPod connection.
        /// Only SetStatusOf method available.
        /// Method GetStatusOf accepts value Extended.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [Func("Init")]
        iPodInit,

        /// <summary>
        /// Option allows to check if iPod device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [Func("Status")]
        iPodStatus,

        /// <summary>
        /// Options allows to choose repeat mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Control")]
        [Func("Rep")]
        iPodRepeat,

        /// <summary>
        /// Options allows to choose random playback (shuffle) mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "Songs", "Albums".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Control")]
        [Func("Rnd")]
        iPodShuffle,

        /// <summary>
        /// Options allows playback control.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        iPodPlayControlPlayback,

        /// <summary>
        /// Option allows select next track or previos one. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts "Skip Fwd", "Skip Rev" values.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        iPodPlayControlPlusMinus,

        /// <summary>
        /// Option provides info about artist.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Artist")]
        iPodPlayInfoArtist,

        /// <summary>
        /// Option provides info about album.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album")]
        iPodPlayInfoAlbum,

        /// <summary>
        /// Option provides info about song.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Song")]
        iPodPlayInfoSong,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Status")]
        iPodPlayInfoStatus,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Playback")]
        iPodPlayInfoPlayback,

        /// <summary>
        /// Options allows to get status of repeat mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Rep")]
        iPodPlayInfoRepeat,

        /// <summary>
        /// Options allows to get status of random playback (shuffle) mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "Songs", "Albums".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Rnd")]
        iPodPlayInfoShuffle,

        /// <summary>
        /// Options allows to get album art URL.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_URL")]
        iPodPlayInfoAlbumArtURL,

        /// <summary>
        /// Options allows to get album art id.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 255 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_ID")]
        iPodPlayInfoAlbumArtID,

        /// <summary>
        /// Options allows to get format of the album art image.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "BMP", "YMF".
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_Forma")]
        iPodPlayInfoAlbumArtFormat,

        /// <summary>
        /// Options allows direct cursor selection from 8 rows on the screen.
        /// Only SetStatusOf method available.
        /// Methods SetStatusOf accepts "Line_[N]" value where [N] is number from 1 to 8 (Line_1, Line_2,...)
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Control")]
        [Func("Direct_Sel")]
        iPodListBrowseControlDirectSelect,

        /// <summary>
        /// Option allows cursor movements. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts Up,Down,Return,Sel,Return to Home values.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Control")]
        [Func("Cursor")]
        iPodListBrowseControlCursor,

        /// <summary>
        /// Option allows jumping to any page in playlist. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Control")]
        [Func("Jump_Line")]
        iPodListBrowseControlJumpPage,

        /// <summary>
        /// Option allows page up or page down control. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value Up,Down.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Control")]
        [Func("Page_Up_Down")]
        iPodListBrowseControlPageUpDown,

        /// <summary>
        /// Option provides status of the menu.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value Ready, Busy.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Status")]
        iPodListBrowseInfoStatus,

        /// <summary>
        /// Option provides selected menu layer number.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value in range from 1 to 16.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Layer")]
        iPodListBrowseInfoLayer,

        /// <summary>
        /// Option provides selected menu layer name.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Name")]
        iPodListBrowseInfoName,

        /// <summary>
        /// Not implemented.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_List")]
        iPodListBrowseInfoList,

        /// <summary>
        /// Option provides info about current line from playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Current_Line")]
        iPodListBrowseInfoCurrentLine,

        /// <summary>
        /// Option provides info about number of songs in the playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 0 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_iPod_USB")]
        [ParentFunc("List_Info")]
        [Func("Max_Line")]
        iPodListBrowseInfoMaxLine,
        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_USB" YNC_Tag="USB">

        /// <summary>
        /// Option allows to check if USB device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [Func("Status")]
        USBStatus,

        /// <summary>
        /// Options allows to choose repeat mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [Func("Rep")]
        USBRepeat,

        /// <summary>
        /// Options allows to turn on or off random playback (shuffle) mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "On".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Control")]
        [Func("Rnd")]
        USBShuffle,

        /// <summary>
        /// Options allows playback control.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        USBPlayControlPlayback,

        /// <summary>
        /// Option allows select next track or previos one. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts "Skip Fwd", "Skip Rev" values.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        [FuncEx("Song")]
        USBPlayControlPlusMinus,

        /// <summary>
        /// Option provides info about artist.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 64 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Artist")]
        USBPlayInfoArtist,

        /// <summary>
        /// Option provides info about Album.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 64 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album")]
        USBPlayInfoAlbum,

        /// <summary>
        /// Option provides info about song.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 64 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Song")]
        USBPlayInfoSong,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Status")]
        USBPlayInfoStatus,

        /// <summary>
        /// Options allows playback control.
        /// Methods SetStatusOf is not available.
        /// Methods GetStatusOf returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Playback")]
        USBPlayInfoPlayback,

        /// <summary>
        /// Options allows to get status of repeat mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Rep")]
        USBPlayInfoRepeat,

        /// <summary>
        /// Options allows to get status of random playback (shuffle) mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "On".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Rnd")]
        USBPlayInfoShuffle,

        /// <summary>
        /// Options allows to get album art URL.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_URL")]
        USBPlayInfoAlbumArtURL,

        /// <summary>
        /// Options allows to get album art id.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 255 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_ID")]
        USBPlayInfoAlbumArtID,

        /// <summary>
        /// Options allows to get format of the album art image.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "BMP", "YMF".
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_Forma")]
        USBPlayInfoAlbumArtFormat,

        /// <summary>
        /// Options allows direct cursor selection from 8 rows on the screen.
        /// Only SetStatusOf method available.
        /// Methods SetStatusOf accepts "Line_[N]" value where [N] is number from 1 to 8 (Line_1, Line_2,...)
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Control")]
        [Func("Direct_Sel")]
        USBListBrowseControlDirectSelect,

        /// <summary>
        /// Option allows cursor movements. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts Up,Down,Return,Sel,Return to Home values.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Control")]
        [Func("Cursor")]
        USBListBrowseControlCursor,

        /// <summary>
        /// Option allows jumping to any page in playlist. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Control")]
        [Func("Jump_Line")]
        USBListBrowseControlJumpLine,

        /// <summary>
        /// Option allows page up or page down control. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value Up,Down.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Control")]
        [Func("Page_Up_Down")]
        USBListBrowseControlPageUpDown,

        /// <summary>
        /// Option provides status of the menu.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value Ready, Busy.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Status")]
        USBListBrowseInfoMenuStatus,

        /// <summary>
        /// Option provides selected menu layer number.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value in range from 1 to 16.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Layer")]
        USBListBrowseInfoMenuLayer,

        /// <summary>
        /// Option provides selected menu layer name.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Name")]
        USBListBrowseInfoMenuName,

        /// <summary>
        /// Not implemented.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_List")]
        USBListBrowseInfoMenuList,

        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Menu_Line")]
        USBListBrowseInfoMenuLine,


        /// <summary>
        /// Option provides info about current line from playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Current_Line")]
        USBListBrowseInfoCurrentLine,

        /// <summary>
        /// Option provides info about number of songs in the playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 0 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_USB")]
        [ParentFunc("List_Info")]
        [Func("Max_Line")]
        USBListBrowseInfoMaxLine,

        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_vTuner" YNC_Tag="NET_RADIO">

        /// <summary>
        /// Option allows to check if NET_RADIO device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [Func("Status")]
        NETRadioStatus,

        /// <summary>
        /// Options allows playback control.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        NETRadioPlayControlPlayback,

        /// <summary>
        /// Option provides info about station.
        /// Method SetStatusOf is not available.
        /// Method GetStatusOf returns station name as string 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Station")]
        NETRadioPlayInfoStation,

        /// <summary>
        /// Option provides info about Album.
        /// Method SetStatusOf is not available.
        /// Method GetStatusOf returns station name as string 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Album")]
        NETRadioPlayInfoAlbum,

        /// <summary>
        /// Option provides info about song.
        /// Method SetStatusOf is not available.
        /// Method GetStatusOf returns station name as string 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Song")]
        NETRadioPlayInfoSong,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Status")]
        NETRadioPlayInfoStatus,

        /// <summary>
        /// Options allows playback control.
        /// Methods SetStatusOf is not available.
        /// Methods GetStatusOf returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Playback")]
        NETRadioPlayInfoPlayback,

        /// <summary>
        /// Options allows to get album art URL.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_URL")]
        NETRadioPlayInfoAlbumArtURL,

        /// <summary>
        /// Options allows to get album art ID.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 255 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_ID")]
        NETRadioPlayInfoAlbumArtID,

        /// <summary>
        /// Options allows to get format of the album art image.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "BMP", "YMF".
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_Forma")]
        NETRadioPlayInfoAlbumArtFormat,

        /// <summary>
        /// Options allows direct cursor selection from 8 rows on the screen.
        /// Only SetStatusOf method available.
        /// Methods SetStatusOf accepts "Line_[N]" value where [N] is number from 1 to 8 (Line_1, Line_2,...)
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Control")]
        [Func("Direct_Sel")]
        NETRadioListBrowseControlDirectSelect,

        /// <summary>
        /// Option allows cursor movements. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts Up,Down,Return,Sel,Return to Home values.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Control")]
        [Func("Cursor")]
        NETRadioListBrowseControlCursor,

        /// <summary>
        /// Option allows jumping to any page in playlist. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Control")]
        [Func("Jump_Line")]
        NETRadioListBrowseControlJumpLine,

        /// <summary>
        /// Option allows page up or page down control. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value Up,Down.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Control")]
        [Func("Page_Up_Down")]
        NETRadioListBrowseControlPageUpDown,

        /// <summary>
        /// Option provides status of the menu.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value Ready, Busy.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Menu_Status")]
        NETRadioListBrowseInfoMenuStatus,

        /// <summary>
        /// Option provides selected menu layer number.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value in range from 1 to 16.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Menu_Layer")]
        NETRadioListBrowseInfoMenuLayer,

        /// <summary>
        /// Option provides selected menu layer name.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Menu_Name")]
        NETRadioListBrowseInfoMenuName,

        /// <summary>
        /// Not Implemented
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Menu_List")]
        NETRadioListBrowseInfoMenuList,

        /// <summary>
        /// Option provides info about current line from playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Current_Line")]
        NETRadioListBrowseInfoCurrentLine,

        /// <summary>
        /// Option provides info about number of songs in the playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 0 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_vTuner")]
        [ParentFunc("List_Info")]
        [Func("Max_Line")]
        NETRadioListBrowseInfoMaxLine,

        #endregion

        #region <Menu Func="Source_Device" Func_Ex="SD_DLNA" YNC_Tag="SERVER">

        /// <summary>
        /// Option allows to check if DLNA device is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [Func("Status")]
        DLNAStatus,

        /// <summary>
        /// Options allows to choose repeat mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Control")]
        [Func("Rep")]
        DLNARepeat,

        /// <summary>
        /// Options allows to turn on or off random playback (shuffle) mode.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Off", "On".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Control")]
        [Func("Rnd")]
        DLNAShuffle,

        /// <summary>
        /// Options allows playback control.
        /// Methods GetStatusOf and SetStatusOf accepts and returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Control")]
        [Func("Playback")]
        DLNAPlayControlPlayback,

        /// <summary>
        /// Option allows select next track or previos one. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts "Skip Fwd", "Skip Rev" values.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Control")]
        [Func("Plus_Minus")]
        [FuncEx("Song")]
        DLNAPlayControlPlusMinus,

        /// <summary>
        /// Option provides info about artist.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Artist")]
        DLNAPlayInfoArtist,

        /// <summary>
        /// Option provides info about album.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Album")]
        DLNAPlayInfoAlbum,

        /// <summary>
        /// Option provides info about song.
        /// Method SetStatusOf not available.
        /// Method GetStatusOf returns value 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Song")]
        DLNAPlayInfoSong,

        /// <summary>
        /// Option allows to check if playback function is ready.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns following values: Ready, Not Ready.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Status")]
        DLNAPlayInfoStatus,

        /// <summary>
        /// Options allows playback control.
        /// Methods SetStatusOf is not available.
        /// Methods GetStatusOf returns "Play", "Pause", "Stop".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Playback")]
        DLNAPlayInfoPlayback,

        /// <summary>
        /// Options allows to get status of repeat mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "One", "All".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Rep")]
        DLNAPlayInfoRepeat,

        /// <summary>
        /// Options allows to get status of random playback (shuffle) mode.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "Off", "On".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Rnd")]
        DLNAPlayInfoShuffle,

        /// <summary>
        /// Options allows to get album art URL.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_URL")]
        DLNAPlayInfoAlbumArtURL,

        /// <summary>
        /// Options allows to get album art ID.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 255 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_ID")]
        DLNAPlayInfoAlbumArtID,

        /// <summary>
        /// Options allows to get format of the album art image.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns "BMP", "YMF".
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("Play_Info")]
        [Func("Album_ART_Forma")]
        DLNAPlayInfoAlbumArtFormat,

        /// <summary>
        /// Options allows direct cursor selection from 8 rows on the screen.
        /// Only SetStatusOf method available.
        /// Methods SetStatusOf accepts "Line_[N]" value where [N] is number from 1 to 8 (Line_1, Line_2,...)
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Control")]
        [Func("Direct_Sel")]
        DLNAListBrowseControlDirectSelect,

        /// <summary>
        /// Option allows cursor movements. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts Up,Down,Return,Sel,Return to Home values.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Control")]
        [Func("Cursor")]
        DLNAListBrowseControlCursor,

        /// <summary>
        /// Option allows jumping to any page in playlist. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Control")]
        [Func("Jump_Line")]
        DLNAListBrowseControlJumpLine,

        /// <summary>
        /// Option allows page up or page down control. 
        /// Only SetStatusOf available.
        /// Method SetStatusOf accepts value Up,Down.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Control")]
        [Func("Page_Up_Down")]
        DLNAListBrowseControlPageUpDown,

        /// <summary>
        /// Option provides status of the menu.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value Ready, Busy.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Menu_Status")]
        DLNAListBrowseInfoStatus,

        /// <summary>
        /// Option provides selected menu layer number.
        /// Only GetStatusOf available.
        /// Method GetStatusOf returns value in range from 1 to 16.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Menu_Layer")]
        DLNAListBrowseInfoLayer,

        /// <summary>
        /// Option provides selected menu layer name.
        /// Only GetStatusOf method available.
        /// Methods GetStatusOf returns text data 128 characters long in UTF-8.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Menu_Name")]
        DLNAListBrowseInfoName,

        /// <summary>
        /// Not implemented
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Menu_List")]
        DLNAListBrowseInfoList,

        /// <summary>
        /// Option provides info about current line from playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 1 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Current_Line")]
        DLNAListBrowseInfoCurrentLine,

        /// <summary>
        /// Option provides info about number of songs in the playlist.
        /// Only GetStatusOf method available.
        /// Method GetStatusOf returns value from 0 to 65536.
        /// </summary>
        [Device("Func_Ex", "SD_DLNA")]
        [ParentFunc("List_Info")]
        [Func("Max_Line")]
        DLNAListBrowseInfoMaxLine

        #endregion

    }
}
