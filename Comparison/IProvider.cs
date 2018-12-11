namespace Comparison
{
    public interface IProvider
    {
        string Name { get; }

        void ParallelIterativeInsertion();

        void NonParallelIterativeInsertion();

        void BulkInsertion();

        void ClearSource();
    }
}
