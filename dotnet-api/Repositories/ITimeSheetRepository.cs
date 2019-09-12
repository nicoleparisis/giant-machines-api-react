using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gm;
using models;

namespace gm_repositories
{
    public interface ITimeSheetRepository
    {
        List<TimeSheetEntry> GetTimeSheetEntries();
        List<TimeSheetEntry> GetTimeSheetEntriesForClient(string client);
        void CreateTimeSheetEntry(TimeSheetEntry entry);
    }
}
