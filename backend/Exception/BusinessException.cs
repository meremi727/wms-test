namespace Exception;

[Serializable]
public class BusinessException : System.Exception
{
    public BusinessException() { }
    public BusinessException(string message) : base(message) { }
    public BusinessException(string message, System.Exception inner) : base(message, inner) { }
}