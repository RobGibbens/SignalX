namespace SignalX
{
	public class ChatMessage
	{
		public string Message { get; set; }

		public string UserId { get; set; }

		public bool IsLocalUser { 
			get { 
				return UserId == App.UserId;
			}
		}
	}
}