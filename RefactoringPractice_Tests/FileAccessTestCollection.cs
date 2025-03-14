
// This attribute tells xUnit to run all tests in this
// collection sequentially so that tests in this collection
// don't run at the same time and cause file access issues
[CollectionDefinition("FileAccessTests", DisableParallelization = true)]
public class FileAccessTestCollection { }