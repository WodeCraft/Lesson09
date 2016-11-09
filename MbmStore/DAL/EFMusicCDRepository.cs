using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MbmStore.DAL
{
    public class EFMusicCDRepository : IMusicCDRepository
    {
        MbmStoreContext context = new MbmStoreContext();

        public IEnumerable<MusicCD> GetMusicCDList()
        {
            return context.MusicCDs.ToList();
        }

        public MusicCD GetMusicCDById(int id)
        {
            return context.MusicCDs.Find(id);
        }

        public void SaveMusicCD(MusicCD musicCD)
        {
            if (musicCD.ProductId == 0)
            {
                musicCD.CreatedDate = DateTime.Now;
                context.MusicCDs.Add(musicCD);
                context.SaveChanges();
            }
            else
            {
                context.Entry(musicCD).State = EntityState.Modified;
                context.Entry(musicCD).Property(b => b.CreatedDate).IsModified = false;
                context.SaveChanges();
            }
        }

        public MusicCD DeleteMusicCD(int id)
        {
            MusicCD musicCD = context.MusicCDs.Find(id);
            if (musicCD != null)
            {
                context.MusicCDs.Remove(musicCD);
                context.SaveChanges();
            }
            return musicCD;
        }
    }
}