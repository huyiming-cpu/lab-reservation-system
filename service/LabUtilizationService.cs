using System;
using System.Collections.Generic;
using LabReservationApp.Entity;
using LabReservationApp.DAO;

namespace LabReservationApp.Service
{
    public class LabUtilizationService
    {
        private readonly LabUtilizationDAO _dao = new LabUtilizationDAO();

        // 获取分页统计数据
        public List<LabUtilizationStats> GetUtilizationStats(DateTime startDate, DateTime endDate, int pageIndex, int pageSize)
        {
            // 日期校验
            if (startDate > endDate)
                throw new ArgumentException("开始日期不能大于结束日期");

            return _dao.GetPagedData(startDate, endDate, pageIndex, pageSize);
        }

        // 获取总记录数
        public int GetTotalCount(DateTime startDate, DateTime endDate)
        {
            return _dao.GetTotalCount(startDate, endDate);
        }
    }
}