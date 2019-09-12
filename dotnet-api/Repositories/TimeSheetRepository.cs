using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using gm;
using models;

namespace gm_repositories
{
    public class TimeSheetRepository: ITimeSheetRepository
    {
        private TimeSheetContext _context;
        public TimeSheetRepository(TimeSheetContext context)
        {
            _context = context;
        }
        public List<TimeSheetEntry> GetTimeSheetEntries()
        {
            return _context.TimeSheetEntries.ToList();
        }
        public List<TimeSheetEntry> GetTimeSheetEntriesForClient(string client)
        {
            return _context.TimeSheetEntries.Where(i => i.Client == client).ToList();
        }
        public void CreateTimeSheetEntry(TimeSheetEntry entry)
        {
           _context.TimeSheetEntries.Add(entry);
        }
    }
}
