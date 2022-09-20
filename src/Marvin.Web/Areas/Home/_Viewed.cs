namespace Marvin.Web.Areas.Home
{
    public record _Viewed
    {
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public string? Name { get; set; }

        public int WhatId { get; set; }
        public string? WhatType { get; set; }
        public string? WhatName { get; set; }
        public DateTime ViewDate { get; set; }
    }
}
