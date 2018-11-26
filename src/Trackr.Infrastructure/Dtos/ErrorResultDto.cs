using System;
using System.Collections.Generic;
using System.Text;

namespace Trackr.Infrastructure.Dtos
{
    public class ErrorResultDto
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
