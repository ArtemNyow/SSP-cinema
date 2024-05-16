using BLL.DTOs;
using Domain.Models;

namespace BLL.Mappers
{
    public static class HallMapper
    {
        public static HallDto ToDto(this Hall hall)
        {
            return new HallDto
            {
                ID = hall.ID,
                Number = hall.Number,
                RowsCount = hall.RowsCount,
                RowsVipCount = hall.RowsVipCount,
                SeatsCountPerRow = hall.SeatsCountPerRow,
                SeatsVipCountPerRow = hall.SeatsVipCountPerRow,
            };
        }

        public static Hall ToEntity(this HallDto hall)
        {
            return new Hall
            {
                ID = hall.ID,
                Number = hall.Number,
                RowsCount = hall.RowsCount,
                RowsVipCount = hall.RowsVipCount,
                SeatsCountPerRow = hall.SeatsCountPerRow,
                SeatsVipCountPerRow = hall.SeatsVipCountPerRow,
            };
        }
    }
}
