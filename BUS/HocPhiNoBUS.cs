﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HocPhiNoBUS
    {
        static public List<HocPhiNoDTO> FindHocPhiNoByIDHocSinh(int mahs)
        {
            return HocPhiNoDAO.FindHocPhiNoByIDHocSinh(mahs);
        }
    }
}
