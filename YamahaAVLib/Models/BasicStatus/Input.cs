using YamahaAVLib.YNC;

namespace YamahaAVLib.Models.BasicStatus
{
    public class Input
    {
        [YNCTag("Input_Sel")]
        public string SelectedInput { get; set; }

        [YNCTag("Input_Sel_Item_Info")]
        public InputInfo SelectedInputInfo { get; set; } = new InputInfo();

    }
}
