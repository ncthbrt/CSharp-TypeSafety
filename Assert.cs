using LanguageExt;
using System.Linq;

namespace Safety
{
  public static class Assert
  {
    public static void True(bool value)
    {
      if (!value)
      {
        Fail();
      }
    }

    public static void Fail()
    {
      throw new InvariantFailureException();
    }

    public static void False(bool value) => True(!value);

    public static void NotNull(params object[] objects) =>
        True(objects.All(o => o != null));

    public static void Some<T>(params Option<T>[] objects) =>
        True(objects.All(o => o.IsSome));

    public static void NotDefault<T>(T value) =>
        NotEqual(value, default(T));

    public static void IsType<T>(object obj) =>
        True(obj is T);

    public static void ReferentiallyEqual<T>(T a, T b) =>
        True(ReferenceEquals(a, b));

    public static void NotEqual<T>(T a, T b) =>
        True(!a.Equals(b));

    public static void Equal<T>(T a, T b) =>
        True(a.Equals(b));
  }
}