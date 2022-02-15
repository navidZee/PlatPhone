using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace PlatPhone.Extention
{
    public static class Validation
    {
        public static bool ValidatorNationalCode(this String nationalCode)
        {
            if (String.IsNullOrEmpty(nationalCode))
                return false;
            if (nationalCode.Length != 10)
                return false;
            if (!Regex.IsMatch(nationalCode, @"^(?!(\d)\1{9})\d{10}$"))
                return false;
            var check = Convert.ToInt32(nationalCode.Substring(9, 1));
            var result = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(nationalCode.Substring(x, 1)) * (10 - x))
                .Sum() % 11;
            int remainder = result % 11;
            return check == (remainder < 2 ? remainder : 11 - remainder);
        }
        public static HttpStatusCode ValidatorFile(IFormFile File, int MaxSize, params string[] Type)
        {
            if ((File.Length / 1024 / 1024) > 2 || !Type.Contains(File.ContentType))
                return HttpStatusCode.NotAcceptable;
            return HttpStatusCode.OK;
        }
    }
}
