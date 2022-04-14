
namespace PortSIP
{
	public interface IPortSIPEvents
	{

		void onRegisterSuccess (string statusText, int statusCode, string sipMessage);
		void onRegisterFailure (string statusText, int statusCode, string sipMessage);

		void onInviteIncoming (long sessionId,
		                       string callerDisplayName,
		                       string caller,
		                       string calleeDisplayName,
		                       string callee,
		                       string audioCodecNames,
		                       string videoCodecNames,
		                       bool existsAudio,
		                       bool existsVideo, 
                               string sipMessage);
		
		void onInviteTrying (long sessionId);
		void onInviteSessionProgress (
			long sessionId,
			string audioCodecNames,
			string videoCodecNames,
			bool existsEarlyMedia,
			bool existsAudio,
			bool existsVideo,
            string sipMessage);
		void onInviteRinging (long sessionId, string statusText, int statusCode, string sipMessage);
        
		void onInviteAnswered (long sessionId,
		                       string callerDisplayName,
		                       string caller,
		                       string calleeDisplayName,
		                       string callee,
		                       string audioCodecNames,
		                       string videoCodecNames,
		                       bool existsAudio,
		                       bool existsVideo,
                               string sipMessage);

		void onInviteFailure (long sessionId, string reason, int code, string sipMessage);
		void onInviteUpdated (
			long sessionId,
			string audioCodecNames,
			string videoCodecNames,
			string screenCodecNames,
			bool existsAudio,
			bool existsVideo,
			bool existsScreen,
			string sipMessage);
		void onInviteConnected (long sessionId);
		void onInviteBeginingForward (string forwardTo);
		void onInviteClosed (long sessionId, string sipMessage);
		void onDialogStateUpdated(string BLFMonitoredUri,
							 string BLFDialogState,
							 string BLFDialogId,
								  string BLFDialogDirection);
		void onRemoteHold (long sessionId);
		void onRemoteUnHold (
			long sessionId, 
			string audioCodecNames,
			string videoCodecNames,
			bool existsAudio,
			bool existsVideo);


		void onReceivedRefer (
			long sessionId,
            long referId,
			string to,
			string referFrom,
			string referSipMessage);
		void onReferAccepted (long sessionId);

		void onReferRejected (long sessionId, string reason, int code);


        //int outOfDialogRefer(int replaceSessionId,string replaceMethod,string target,string referTo);

		void onTransferTrying (long sessionId);

		void onTransferRinging (long sessionId);

		void onACTVTransferSuccess (long sessionId);

		void onACTVTransferFailure (long sessionId, string reason, int code);

		void onReceivedSignaling (long sessionId, string signaling);

		void onSendingSignaling (long sessionId, string signaling);

		void onWaitingVoiceMessage (
			string messageAccount,
			int urgentNewMessageCount,
			int urgentOldMessageCount,
			int newMessageCount,
			int oldMessageCount);
			
		void onWaitingFaxMessage (
			string messageAccount,
			int urgentNewMessageCount,
			int urgentOldMessageCount,
			int newMessageCount,
			int oldMessageCount);
			
		void onRecvDtmfTone (long sessionId, int tone);

		void onRecvOptions (string optionsMessage);

		void onRecvInfo (string infoMessage);

        void onRecvNotifyOfSubscription(long sessionId, string notifyMessage, byte[] messageData, int messageDataLength);

		void onPresenceRecvSubscribe (
			long subscribeId,
			string fromDisplayName,
			string from,
			string subject);

		void onPresenceOnline (string fromDisplayName, string from, string stateText);

		void onPresenceOffline (string fromDisplayName, string from);

		void onRecvMessage (
			long sessionId,
			string mimeType,
			string subMimeType,
			byte[] messageData,
			int messageDataLength);

		void onRecvOutOfDialogMessage (
			string fromDisplayName,
			string from,
			string toDisplayName,
			string to,
			string mimeType,
			string subMimeType,
			byte[] messageData,
            int messageDataLength,
            string sipMessage);

        void onSendMessageSuccess (long sessionId, long messageId, string sipMessage);

		void onSendMessageFailure (long sessionId, long messageId, string reason, int code, string sipMessage);

		void onSendOutOfDialogMessageSuccess (long messageId,
		                                      string fromDisplayName,
		                                      string from,
		                                      string toDisplayName,
		                                      string to,
											  string sipMessage);

		void onSendOutOfDialogMessageFailure (
			long messageId,
			string fromDisplayName,
			string from,
			string toDisplayName,
			string to,
			string reason,
			int code,
			string sipMessage);

		void onSubscriptionFailure(long subscribeId, int statusCode);

		void onSubscriptionTerminated(long subscribeId);

		void onPlayAudioFileFinished (long sessionId, string fileName);

		void onPlayVideoFileFinished (long sessionId);

		void onRTPPacketCallback(long sessionId, int mediaType, DIRECTION_MODE direction, byte[] RTPPacket, int packetSize);

		void onAudioRawCallback (
			long sessionId,
			int callbackType,
			byte[] data,
			int dataLength,
			int samplingFreqHz);

		int onVideoRawCallback (
			long sessionId,
			int callbackType,
			int width,
			int height,
			byte[] data,
			int dataLength);

		void OnAudioDeviceChanged(AUDIO_DEVICE currentAudioDevice,
			   System.Collections.ICollection availableAudioDevices);

	}

}
