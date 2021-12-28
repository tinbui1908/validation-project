namespace MyFramework
{
    /// <summary>
    /// Define validator types
    /// </summary>
    public enum ValidatorType
    {
        // Not null type
        NOT_NULL,
        // Regular expression type
        REGEX,
        // Phone number type
        PHONE_NUMBER,
        // Max length of string type
        MAX_LENGTH,
        // Min length of string type
        MIN_LENGTH,
        // Scope of string length (from .. to) type
        LENGTH,
        // Scope of number (from .. to) type
        RANGE,
        // Date (day, month and year) type
        DATE_OF_BIRTH,
        // Have no blank ('_') type
        NO_BLANK,
        // Have blank(s) ('_') type
        BLANK,
        // Is a number type
        IS_NUMBER
    }
}