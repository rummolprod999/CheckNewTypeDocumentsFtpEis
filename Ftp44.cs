using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CheckNewTypeDocumentsFtpEis
{
    public class Ftp44 : Ftp
    {
        protected DataTable DtRegion;
        private string[] _dirsftp = {"purchaseNoticeAESMBO", "purchaseNoticeZKESMBO", "purchaseNoticeZPESMBO"};

        public Ftp44(Arguments arg)
        {
        }

        public override void CheckFtp()
        {
            DtRegion = GetRegions();
            foreach (DataRow row in DtRegion.Rows)
            {
                var regionPath = (string) row["path"];
                CheckPath(regionPath, in _dirsftp);
            }
        }

        private void CheckPath(string pathRow, in string[] arch)
        {
            foreach (var v in arch)
            {
                var path = $"/fcs_regions/{pathRow}/{v}/daily/";
                var ls = GetListArchCurr(path);
                if (ls.Count > 0)
                {
                    foreach (var l in ls)
                    {
                        Console.WriteLine(l);
                        using (var sw = new StreamWriter("list44.txt", true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(l);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("empty path");
                }
            }
        }

        protected override List<string> GetListFtp(string pathParse)
        {
            var ftp = new WorkWithFtp("ftp://ftp.zakupki.gov.ru", "free", "free");
            ftp.ChangeWorkingDirectory(pathParse);
            return ftp.ListDirectory();
        }
    }
}