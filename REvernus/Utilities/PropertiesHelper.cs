namespace REvernus.Utilities
{
    public static class PropertiesHelper
    {
        public static void CopyProperties<T>(T from, T to)
        {
            if (from == null || to == null) return;
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                var firstValue = propertyInfo.GetValue(from, null);
                var secondValue = propertyInfo.GetValue(to, null);
                if (!Equals(firstValue, secondValue)) propertyInfo.SetValue(to, firstValue, null);
            }
        }
    }
}