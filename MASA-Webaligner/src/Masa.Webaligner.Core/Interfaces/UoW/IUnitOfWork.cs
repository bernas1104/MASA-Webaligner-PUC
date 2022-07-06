namespace Masa.Webaligner.Core.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        int Commit();
        void BeginTransaction();
        void BeginCommit();
        void BeginRollBack();
    }
}
