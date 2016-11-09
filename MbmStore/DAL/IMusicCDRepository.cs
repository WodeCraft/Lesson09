using MbmStore.Models;
using System.Collections.Generic;

namespace MbmStore.DAL
{
    public interface IMusicCDRepository
    {
        IEnumerable<MusicCD> GetMusicCDList();
        MusicCD GetMusicCDById(int id);
        void SaveMusicCD(MusicCD musicCD);
        MusicCD DeleteMusicCD(int id);
    }
}
