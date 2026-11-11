using System.Collections.Generic;
using LabReservationApp.DAO;
using LabReservationApp.Entity;

namespace LabReservationApp.Service
{
    public class LaboratoryService
    {
        private readonly LaboratoryDAO _labDAO = new LaboratoryDAO();

        // 获取实验室列表（分页）
        public List<Laboratory> GetLaboratories(string keyword, int pageIndex, int pageSize)
        {
            // 检查参数合法性
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;

            return _labDAO.GetLaboratories(keyword, pageIndex, pageSize);
        }

        // 获取实验室总数
        public int GetTotalCount(string keyword)
        {
            return _labDAO.GetTotalCount(keyword);
        }
    }
}