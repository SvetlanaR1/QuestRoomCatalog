using QuestRoomCatalog.BusinessLayer.BusinessObjects;
using QuestRoomCatalog.DataLayer;
using QuestRoomCatalog.DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestRoomCatalog.BusinessLayer.Helpers
{
    public class QuestLogosHelper
    {
        UnitOfWork<QuestsLogos> Db { get; set; }

        public QuestLogosHelper(UnitOfWork<QuestsLogos> uow)
        {
            Db = uow;
        }

        public void Create(QuestsLogosBO Bo)
        {
            if(Bo.Id == 0)
            {
                QuestsLogos questLogos = AutoMapper<QuestsLogosBO, QuestsLogos>.Map(Bo);
                Db.GenericUowRepository.Add(questLogos);
                Db.Save();
            }

        }
    }
}
