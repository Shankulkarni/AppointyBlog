using System;

namespace Appointy.Portable
{
    public enum MenuType
    {
        About,
        Hanselminutes,
    }
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.About;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}

