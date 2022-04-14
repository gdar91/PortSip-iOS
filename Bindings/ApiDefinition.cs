using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using PortSIP;

namespace PortSip_iOS.Bindings
{

// The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
// to the project.
// Open your binding csproj and add a section like this
// <ItemGroup>
//   <NativeReference Include="MyLibrary.xcframework">
//     <Kind>Framework</Kind>
//     <Frameworks></Frameworks>
//   </NativeReference>
// </ItemGroup>
//
// Once you've added it, you will need to customize it for your specific library:
//  - Change the Include to the correct path/name of your library
//  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
//    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
//  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
// Example:
// <NativeReference Include="libs\MyTestFramework.xcframework">
//   <Kind>Framework</Kind>
//   <Frameworks>CoreLocation ModelIO</Frameworks>
// </NativeReference>
// 
// Once you've done that, you're ready to move on to binding the API...
//
// Here is where you'd define your API definition for the native Objective-C library.
//
// For example, to bind the following Objective-C class:
//
//     @interface Widget : NSObject {
//     }
//
// The C# binding would look like this:
//
//     [BaseType (typeof (NSObject))]
//     interface Widget {
//     }
//
// To bind Objective-C properties, such as:
//
//     @property (nonatomic, readwrite, assign) CGPoint center;
//
// You would add a property definition in the C# interface like so:
//
//     [Export ("center")]
//     CGPoint Center { get; set; }
//
// To bind an Objective-C method, such as:
//
//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
//
// You would add a method definition to the C# interface like so:
//
//     [Export ("doSomething:atIndex:")]
//     void DoSomething (NSObject object, nint index);
//
// Objective-C "constructors" such as:
//
//     -(id)initWithElmo:(ElmoMuppet *)elmo;
//
// Can be bound as:
//
//     [Export ("initWithElmo:")]
//     NativeHandle Constructor (ElmoMuppet elmo);
//
// For more information, see https://aka.ms/ios-binding
//

    [BaseType(typeof(NSObject))]
    [Protocol]
    [Model]
    public partial interface PortSIPEventDelegate
    {

        [Export("onRegisterSuccess:statusCode:sipMessage:")]
        void onRegisterSuccess(IntPtr statusText, int statusCode, IntPtr sipMessage);

        [Export("onRegisterFailure:statusCode:sipMessage:")]
        void onRegisterFailure(IntPtr statusText, int statusCode,IntPtr sipMessage);

        [Export("onInviteIncoming:callerDisplayName:caller:calleeDisplayName:callee:audioCodecs:videoCodecs:existsAudio:existsVideo:sipMessage:")]
        void onInviteIncoming(
            nint sessionId,
            IntPtr callerDisplayName,
            IntPtr caller,
            IntPtr calleeDisplayName,
            IntPtr callee,
            IntPtr audioCodecNames,
            IntPtr videoCodecNames,
            bool existsAudio,
            bool existsVideo,
            IntPtr sipMessage);


        [Export("onInviteTrying:")]
        void onInviteTrying(nint sessionId);

        [Export("onInviteRinging:withHasEarlyMedia:")]
        void onInviteRinging(nint sessionId, bool hasEarlyMedia);

        [Export("onInviteSessionProgress:audioCodecs:videoCodecs:existsEarlyMedia:existsAudio:existsVideo:sipMessage:")]
        void onInviteSessionProgress(
            nint sessionId,
            IntPtr audioCodecNames,
            IntPtr videoCodecNames,
            bool existsEarlyMedia,
            bool existsAudio,
            bool existsVideo,
            IntPtr sipMessage);

        [Export("onInviteRinging:statusText:statusCode:sipMessage:")]
        void onInviteRinging(nint sessionId, IntPtr statusText, int statusCode, IntPtr sipMessage);

        [Export("onInviteAnswered:callerDisplayName:caller:calleeDisplayName:callee:audioCodecs:videoCodecs:existsAudio:existsVideo:sipMessage:")]
        void onInviteAnswered(nint sessionId,
            IntPtr callerDisplayName,
            IntPtr caller,
            IntPtr calleeDisplayName,
            IntPtr callee,
            IntPtr audioCodecNames,
            IntPtr videoCodecNames,
            bool existsAudio,
            bool existsVideo,
            IntPtr sipMessage);

        [Export("onInviteFailure:reason:code:sipMessage:")]
        void onInviteFailure(nint sessionId, IntPtr reason, int code, IntPtr sipMessage);

        [Export("onInviteUpdated:audioCodecs:videoCodecs:screenCodecNames:existsAudio:existsVideo:existsScreen:sipMessage:")]
        void onInviteUpdated(
            nint sessionId,
            IntPtr audioCodecNames,
            IntPtr videoCodecNames,
            IntPtr screenCodecNames,
            bool existsAudio,
            bool existsVideo,
            bool existsScreen,
            IntPtr sipMessage);

        [Export("onInviteConnected:")]
        void onInviteConnected(nint sessionId);

        [Export("onInviteBeginingForward:")]
        void onInviteBeginingForward(IntPtr forwardTo);

        [Export("onInviteClosed:sipMessage:")]
        void onInviteClosed(nint sessionId, IntPtr sipMessage);

        [Export("onDialogStateUpdated:BLFDialogState:BLFDialogId:BLFDialogDirection:")]
        void onDialogStateUpdated(IntPtr BLFMonitoredUri,
                                    IntPtr BLFDialogState,
                                    IntPtr BLFDialogId,
                                    IntPtr BLFDialogDirection);

        [Export("onRemoteHold:")]
        void onRemoteHold(nint sessionId);

        [Export("onRemoteUnHold:audioCodecs:videoCodecs:existsAudio:existsVideo:")]
        void onRemoteUnHold(
            nint sessionId,
            IntPtr audioCodecNames,
            IntPtr videoCodecNames,
            bool existsAudio,
            bool existsVideo);

        [Export("onReceivedRefer:referId:to:from:referSipMessage:")]
        void onReceivedRefer(
            nint sessionId,
            int referId,
            IntPtr to,
            IntPtr referFrom,
            IntPtr referSipMessage);

        [Export("onReferAccepted:")]
        void onReferAccepted(nint sessionId);

        [Export("onReferRejected:reason:code:")]
        void onReferRejected(nint sessionId, IntPtr reason, int code);

        [Export("onTransferTrying:")]
        void onTransferTrying(nint sessionId);

        [Export("onTransferRinging:")]
        void onTransferRinging(nint sessionId);

        [Export("onACTVTransferSuccess:")]
        void onACTVTransferSuccess(nint sessionId);

        [Export("onACTVTransferFailure:reason:code:")]
        void onACTVTransferFailure(nint sessionId, IntPtr reason, int code);

        [Export("onReceivedSignaling:message:")]
        void onReceivedSignaling(nint sessionId, IntPtr signaling);

        [Export("onSendingSignaling:message:")]
        void onSendingSignaling(nint sessionId, IntPtr signaling);

        [Export("onWaitingVoiceMessage:urgentNewMessageCount:urgentOldMessageCount:newMessageCount:oldMessageCount:")]
        void onWaitingVoiceMessage(
            IntPtr messageAccount,
            int urgentNewMessageCount,
            int urgentOldMessageCount,
            int newMessageCount,
            int oldMessageCount);

        [Export("onWaitingFaxMessage:urgentNewMessageCount:urgentOldMessageCount:newMessageCount:oldMessageCount:")]
        void onWaitingFaxMessage(
            IntPtr messageAccount,
            int urgentNewMessageCount,
            int urgentOldMessageCount,
            int newMessageCount,
            int oldMessageCount);

        [Export("onRecvDtmfTone:tone:")]
        void onRecvDtmfTone(nint sessionId, int tone);

        [Export("onRecvOptions:")]
        void onRecvOptions(IntPtr optionsMessage);

        [Export("onRecvInfo:")]
        void onRecvInfo(IntPtr infoMessage);

        [Export("onRecvNotifyOfSubscription:notifyMessage:messageData:messageDataLength:")]
        void onRecvNotifyOfSubscription(nint sessionId, IntPtr notifyMessage, IntPtr messageData,int messageDataLength);


        [Export("onPresenceRecvSubscribe:fromDisplayName:from:subject:")]
        void onPresenceRecvSubscribe(
            nint subscribeId,
            IntPtr fromDisplayName,
            IntPtr from,
            IntPtr subject);

        [Export("onPresenceOnline:from:stateText:")]
        void onPresenceOnline(IntPtr fromDisplayName, IntPtr from, IntPtr stateText);

        [Export("onPresenceOffline:from:")]
        void onPresenceOffline(IntPtr fromDisplayName, IntPtr from);


        [Export("onRecvMessage:mimeType:subMimeType:messageData:messageDataLength:")]
        void onRecvMessage(
            nint sessionId,
            IntPtr mimeType,
            IntPtr subMimeType,
            IntPtr messageData,
            int messageDataLength);

        [Export("onRecvOutOfDialogMessage:from:toDisplayName:to:mimeType:subMimeType:messageData:messageDataLength:sipMessage:")]
        void onRecvOutOfDialogMessage(
            IntPtr fromDisplayName,
            IntPtr from,
            IntPtr toDisplayName,
            IntPtr to,
            IntPtr mimeType,
            IntPtr subMimeType,
            IntPtr messageData,
            int messageDataLength,
            IntPtr sipMessage);

        [Export("onSendMessageSuccess:messageId:sipMessage:")]
        void onSendMessageSuccess(nint sessionId, nint messageId, IntPtr sipMessage);

        [Export("onSendMessageFailure:messageId:reason:code:sipMessage:")]
        void onSendMessageFailure(nint sessionId, nint messageId, IntPtr reason, int code, IntPtr sipMessage);

        [Export("onSendOutOfDialogMessageSuccess:fromDisplayName:from:toDisplayName:to:sipMessage:")]
        void onSendOutOfDialogMessageSuccess(nint messageId,
            IntPtr fromDisplayName,
            IntPtr from,
            IntPtr toDisplayName,
            IntPtr to,
            IntPtr sipMessage);

        [Export("onSendOutOfDialogMessageFailure:fromDisplayName:from:toDisplayName:to:reason:code:sipMessage:")]
        void onSendOutOfDialogMessageFailure(
            nint messageId,
            IntPtr fromDisplayName,
            IntPtr from,
            IntPtr toDisplayName,
            IntPtr to,
            IntPtr reason,
            int code,
            IntPtr sipMessage);

        [Export("onSubscriptionFailure:statusCode:")]
        void onSubscriptionFailure(nint subscribeId, int statusCode);

        [Export("onSubscriptionTerminated:")]
        void onSubscriptionTerminated(nint subscribeId);

        [Export("onPlayAudioFileFinished:fileName:")]
        void onPlayAudioFileFinished(nint sessionId, IntPtr fileName);

        [Export("onPlayVideoFileFinished:")]
        void onPlayVideoFileFinished(nint sessionId);

        [Export("onRTPPacketCallback:mediaType:direction:RTPPacket:packetSize:")]
        void onRTPPacketCallback(
            nint sessionId,
            int mediaType,
            DIRECTION_MODE direction,
            IntPtr RTPPacket,
            int packetSize);

        [Export("onAudioRawCallback:audioCallbackMode:data:dataLength:samplingFreqHz:")]
        void onAudioRawCallback(
            nint sessionId,
            int callbackType,
            IntPtr data,
            int dataLength,
            int samplingFreqHz);

        [Export("onVideoRawCallback:videoCallbackMode:width:height:data:dataLength:")]
        int onVideoRawCallback(
            nint sessionId,
            int callbackType,
            int width,
            int height,
            IntPtr data,
            int dataLength);
    }

    [BaseType(typeof(UIView))]
    public partial interface PortSIPVideoRenderView
    {
        [Export("initVideoRender")]
        void initVideoRender();

        [Export("releaseVideoRender")]
        void releaseVideoRender();

        [Export("getVideoRenderView")]
        IntPtr getVideoRenderView();

        [Export("updateVideoRenderFrame:")]
        void updateVideoRenderFrame(CGRect frameRect);
    }

    [BaseType(typeof(NSObject))]
    public partial interface PortSIPSDK
    {

        [Export("delegate", ArgumentSemantic.Retain)]
        PortSIPEventDelegate Delegate { get; set; }

        [Export("initialize:localIP:localSIPPort:loglevel:logPath:maxLine:agent:audioDeviceLayer:videoDeviceLayer:TLSCertificatesRootPath:TLSCipherList:verifyTLSCertificate:dnsServers:")]
        int initialize(TRANSPORT_TYPE transport,
                        string localIP,
                        int localSIPPort,
                        PORTSIP_LOG_LEVEL logLevel,
                        string logFilePath,
                        int maxCallLines,
                        string sipAgent,
                        int audioDeviceLayer,
                        int videoDeviceLayer,
                        string tlsCertificatesRootPath,
                        string tlsCipherList,
                        bool verifyTLSCertificate,
                        string dnsServers);

        [Export("unInitialize")]
        void unInitialize();

        [Export("setUser:displayName:authName:password:userDomain:SIPServer:SIPServerPort:STUNServer:STUNServerPort:outboundServer:outboundServerPort:")]
        int setUser(string userName,
                    string displayName,
                    string authName,
                    string password,
                    string userDomain,
                    string sipServer,
                    int sipServerPort,
                    string stunServer,
                    int stunServerPort,
                    string outboundServer,
                    int outboundServerPort);

        [Export("removeUser")]
        void removeUser();

        [Export("registerServer:retryTimes:")]
        int registerServer(int expires, int retryTimes);

        [Export("refreshRegistration:")]
        int refreshRegistration(int expires);


        [Export("unRegisterServer")]
        int unRegisterServer();

        [Export("setInstanceId:")]
        int setInstanceId(string instanceId);

        [Export("setLicenseKey:")]
        int setLicenseKey(string key);

        [Export("getNICNums")]
        int getNICNums();

        [Export("getLocalIpAddress:")]
        string getLocalIpAddress(int index);

        [Export("addAudioCodec:")]
        int addAudioCodec(AUDIOCODEC_TYPE codecType);

        [Export("addVideoCodec:")]
        int addVideoCodec(VIDEOCODEC_TYPE codecType);

        [Export("isAudioCodecEmpty")]
        bool isAudioCodecEmpty();

        [Export("isVideoCodecEmpty")]
        bool isVideoCodecEmpty();

        [Export("setAudioCodecPayloadType:payloadType:")]
        int setAudioCodecPayloadType(AUDIOCODEC_TYPE codecType, int payloadType);


        [Export("setVideoCodecPayloadType:payloadType:")]
        int setVideoCodecPayloadType(VIDEOCODEC_TYPE codecType, int payloadType);

        [Export("clearAudioCodec")]
        void clearAudioCodec();

        [Export("clearVideoCodec")]
        void clearVideoCodec();

        [Export("setAudioCodecParameter:parameter:")]
        int setAudioCodecParameter(AUDIOCODEC_TYPE codecType, string parameter);

        [Export("setVideoCodecParameter:parameter:")]
        int setVideoCodecParameter(VIDEOCODEC_TYPE codecType, string parameter);


        [Export("getVersion")]
        String getVersion();
        
        [Export("enableRport:")]
        int enableRport(bool enable);

        [Export("enableEarlyMedia:")]
        int enableEarlyMedia(bool enable);

        [Export("enableReliableProvisional:")]
        int enableReliableProvisional(bool enable);

        [Export("enable3GppTags:")]
        int enable3GppTags(bool enable);

        [Export("enableCallbackSignaling:enableReceived:")]
        void enableCallbackSignaling(bool enableSending, bool enableReceived);

        [Export("setSrtpPolicy:")]
        int setSrtpPolicy(SRTP_POLICY srtpPolicy);

        [Export("setRtpPortRange:maximumRtpPort:")]
        int setRtpPortRange(int minimumRtpPort, int maximumRtpPort);

        [Export("enableCallForward:forwardTo:")]
        int enableCallForward(bool forBusyOnly, string forwardTo);

        [Export("disableCallForward")]
        int disableCallForward();

        [Export("enableSessionTimer:refreshMode:")]
        int enableSessionTimer(int timerSeconds, SESSION_REFRESH_MODE refreshMode);

        [Export("disableSessionTimer")]
        int disableSessionTimer();

        [Export("setDoNotDisturb:")]
        void setDoNotDisturb(bool state);



        [Export("enableAutoCheckMwi:")]
        int enableAutoCheckMwi(bool state);

        [Export("setRtpKeepAlive:keepAlivePayloadType:deltaTransmitTimeMS:")]
        int setRtpKeepAlive(bool state, int keepAlivePayloadType, int deltaTransmitTimeMS);

        [Export("setKeepAliveTime:")]
        int setKeepAliveTime(int keepAliveTime);

        [Export("setAudioSamples:maxPtime:")]
        int setAudioSamples(int ptime, int maxPtime);

        [Export("addSupportedMimeType:mimeType:subMimeType:")]
        int addSupportedMimeType(string methodName, string mimeType, string subMimeType);


        [Export("getSipMessageHeaderValue:headerName:")]
        string getSipMessageHeaderValue(string sipMessage, string headerName);

        [Export("addSipMessageHeader:methodName:msgType:headerName:headerValue:")]
        nint addSipMessageHeader(nint sessionId, string methodName, int msgType, string headerName, string headerValue);


        [Export("removeAddedSipMessageHeader:")]
        int removeAddedSipMessageHeader(int addedSipMessageId);

        [Export("clearAddedSipMessageHeaders")]
        void clearAddedSipMessageHeaders();


        [Export("modifySipMessageHeader:methodName:msgType:headerName:headerValue:")]
        nint modifySipMessageHeader(nint sessionId, string methodName, int msgType, string headerName, string headerValue);
        
        [Export("removeModifiedSipMessageHeader:")]
        int removeModifiedSipMessageHeader(int modifiedSipMessageId);

        [Export("clearModifiedSipMessageHeaders")]
        void clearModifiedSipMessageHeaders();


        [Export("setVideoDeviceId:")]
        int setVideoDeviceId(int deviceId);

        [Export("setVideoResolution:height:")]
        int setVideoResolution(int width, int height);

        [Export("setVideoOrientation:")]
        int setVideoOrientation(int rotation);

        [Export("setVideoCropAndScale:")]
        int setVideoCropAndScale(bool enable);

        [Export("setAudioBitrate:codecType:bitrateKbps:")]
        int setAudioBitrate(nint sessionId, AUDIOCODEC_TYPE codecType, int bitrateKbps);

        [Export("setVideoBitrate:bitrateKbps:")]
        int setVideoBitrate(nint sessionId, int bitrateKbps);


        [Export("setVideoFrameRate:frameRate:")]
        int setVideoFrameRate(nint sessionId, int frameRate);


        [Export("sendVideo:sendState:")]
        int sendVideo(nint sessionId, bool sendState);


        [Export("setRemoteVideoWindow:remoteVideoWindow:")]
        int setRemoteVideoWindow(nint sessionId, [NullAllowed] PortSIPVideoRenderView remoteVideoWindow);


        [Export("displayLocalVideo:mirror:localVideoWindow:")]
        int displayLocalVideo(bool state, bool mirror, [NullAllowed] PortSIPVideoRenderView localVideoWindow);


        [Export("setVideoNackStatus:")]
        int setVideoNackStatus(bool state);


        [Export("setLoudspeakerStatus:")]
        int setLoudspeakerStatus(bool enable);

        [Export("setChannelOutputVolumeScaling:scaling:")]
        int setChannelOutputVolumeScaling(nint sessionId, int scaling);

        [Export("setChannelInputVolumeScaling:scaling:")]
        int setChannelInputVolumeScaling(nint sessionId, int scaling);

        [Export("call:sendSdp:videoCall:")]
        nint call(string callee, bool sendSdp, bool videoCall);

        [Export("rejectCall:code:")]
        int rejectCall(nint sessionId, int code);

        [Export("hangUp:")]
        int hangUp(nint sessionId);

        [Export("answerCall:videoCall:")]
        int answerCall(nint sessionId, bool videoCall);

        [Export("updateCall:enableAudio:enableVideo:")]
        int updateCall(nint sessionId, bool enableAudio, bool enableVideo);

        [Export("hold:")]
        int hold(nint sessionId);

        [Export("unHold:")]
        int unHold(nint sessionId);

        [Export("muteSession:muteIncomingAudio:muteOutgoingAudio:muteIncomingVideo:muteOutgoingVideo:")]
        int muteSession(nint sessionId,
            bool muteIncomingAudio,
            bool muteOutgoingAudio,
            bool muteIncomingVideo,
            bool muteOutgoingVideo);

        [Export("forwardCall:forwardTo:")]
        int forwardCall(nint sessionId, string forwardTo);

        [Export("sendDtmf:dtmfMethod:code:dtmfDration:playDtmfTone:")]
        int sendDtmf(nint sessionId, DTMF_METHOD dtmfMethod, int code, int dtmfDuration, bool playDtmfTone);

        [Export("refer:referTo:")]
        int refer(nint sessionId, string referTo);

        [Export("attendedRefer:replaceSessionId:referTo:")]
        int attendedRefer(nint sessionId, nint replaceSessionId, string referTo);

        [Export("attendedRefer2:replaceSessionId:replaceMethod:target:referTo:")]
        int attendedRefer2(nint sessionId,
                            nint replaceSessionId,
                            string replaceMethod,
                                string target,
                            string referTo);

        [Export("acceptRefer:referSignaling:")]
        nint acceptRefer(int referId, string referSignalingMessage);

        [Export("outOfDialogRefer:replaceMethod:target:referTo:")]
        int outOfDialogRefer(nint replaceSessionId,
                                string replaceMethod,
                                string target,
                                string referTo);

        [Export("rejectRefer:")]
        int rejectRefer(int referId);

        [Export("enableSendPcmStreamToRemote:state:streamSamplesPerSec:")]
        int enableSendPcmStreamToRemote(nint sessionId, bool state, int streamSamplesPerSec);

        [Export("sendPcmStreamToRemote:data:")]
        int sendPcmStreamToRemote(nint sessionId, NSData data);

        [Export("enableSendVideoStreamToRemote:state:")]
        int enableSendVideoStreamToRemote(nint sessionId, bool state);

        [Export("sendVideoStreamToRemote:data:width:height:")]
        int sendVideoStreamToRemote(nint sessionId, NSData data, int width, int height);

        [Export("enableRtpCallback:mediaType:mode:")]
        int enableRtpCallback(nint sessionId, int mediaType, DIRECTION_MODE mode);

        [Export("enableAudioStreamCallback:enable:callbackMode:")]
        int enableAudioStreamCallback(nint sessionId, bool enable, DIRECTION_MODE callbackMode);

        [Export("enableVideoStreamCallback:callbackMode:")]
        int enableVideoStreamCallback(nint sessionId, DIRECTION_MODE callbackMode);


        [Export("startRecord:recordFilePath:recordFileName:appendTimeStamp:audioFileFormat:audioRecordMode:aviFileCodecType:videoRecordMode:")]
        int startRecord(nint sessionId,
            string recordFilePath,
            string recordFileName,
            bool appendTimestamp,
            AUDIO_RECORDING_FILEFORMAT audioFileFormat,
            RECORD_MODE audioRecordMode,
            VIDEOCODEC_TYPE videoFileCodecType,
            RECORD_MODE videoRecordMode);

        [Export("stopRecord:")]
        int stopRecord(nint sessionId);

        [Export("playVideoFileToRemote:aviFile:loop:playAudio:")]
        int playVideoFileToRemote(nint sessionId, string fileName, bool loop, bool playAudio);

        [Export("stopPlayVideoFileToRemote:")]
        int stopPlayVideoFileToRemote(nint sessionId);

        [Export("playAudioFileToRemote:filename:fileSamplesPerSec:loop:")]
        int playAudioFileToRemote(nint sessionId, string fileName, int fileSamplesPerSec, bool loop);

        [Export("stopPlayAudioFileToRemote:")]
        int stopPlayAudioFileToRemote(nint sessionId);

        [Export("playAudioFileToRemoteAsBackground:filename:fileSamplesPerSec:")]
        int playAudioFileToRemoteAsBackground(nint sessionId, string fileName, int fileSamplesPerSec);

        [Export("stopPlayAudioFileToRemoteAsBackground:")]
        int stopPlayAudioFileToRemoteAsBackground(nint sessionId);

        [Export("createAudioConference")]
        int createAudioConference();

        [Export("createVideoConference:videoWidth:videoHeight:displayLocalVideo:")]
        int createVideoConference([NullAllowed] PortSIPVideoRenderView conferenceVideoWindow,
                                    int videoWidth,
                                    int videoHeight,
                                    bool displayLocalVideoInConference);

        [Export("destroyConference")]
        void destroyConference();

        [Export("setConferenceVideoWindow:")]
        int setConferenceVideoWindow([NullAllowed] PortSIPVideoRenderView videoWindow);

        [Export("joinToConference:")]
        int joinToConference(nint sessionId);

        [Export("removeFromConference:")]
        int removeFromConference(nint sessionId);

        [Export("setAudioRtcpBandwidth:BitsRR:BitsRS:KBitsAS:")]
        int setAudioRtcpBandwidth(nint sessionId,
            int BitsRR,
            int BitsRS,
            int KBitsAS);

        [Export("setVideoRtcpBandwidth:BitsRR:BitsRS:KBitsAS:")]
        int setVideoRtcpBandwidth(nint sessionId,
            int BitsRR,
            int BitsRS,
            int KBitsAS);

        [Export("enableAudioQos:")]
        int enableAudioQos(bool state);

        [Export("enableVideoQos:")]
        int enableVideoQos(bool state);

        [Export("setVideoMTU:")]
        int setVideoMTU(int mtu);


        [Export("getAudioStatistics:sendBytes:sendPackets:sendPacketsLost:sendFractionLost:sendRttMS:sendCodecType:sendJitterMS:sendAudioLevel:recvBytes:recvPackets:recvPacketsLost:recvFractionLost:recvCodecType:recvJitterMS:recvAudioLevel:")]
        int getAudioStatistics(nint sessionId,
                                out int sendBytes,
                                out int sendPackets,
                                out int sendPacketsLost,
                                out int sendFractionLost,
                                out int sendRttMS,
                                out int sendCodecType,
                                out int sendJitterMS,
                                out int sendAudioLevel,
                                out int recvBytes,
                                out int recvPackets,
                                out int recvPacketsLost,
                                out int recvFractionLost,
                                out int recvCodecType,
                                out int recvJitterMS,
                                out int recvAudioLevel);
        
                
        [Export("getVideoStatistics:sendBytes:sendPackets:sendPacketsLost:sendFractionLost:sendRttMS:sendCodecType:sendFrameWidth:sendFrameHeight:sendBitrateBPS:sendFramerate:recvBytes:recvPackets:recvPacketsLost:recvFractionLost:recvCodecType:recvFrameWidth:recvFrameHeight:recvBitrateBPS:recvFramerate:")]
        int getVideoStatistics(nint sessionId,
                                out int sendBytes,
                                out int sendPackets,
                                out int sendPacketsLost,
                                out int sendFractionLost,
                                out int sendRttMS,
                                out int sendCodecType,
                                out int sendFrameWidth,
                                out int sendFrameHeight,
                                out int sendBitrateBPS,
                                out int sendFramerate,
                                out int recvBytes,
                                out int recvPackets,
                                out int recvPacketsLost,
                                out int recvFractionLost,
                                out int recvCodecType,
                                out int recvFrameWidth,
                                out int recvFrameHeight,
                                out int recvBitrateBPS,
                                out int recvFramerate);


        [Export("enableVAD:")]
        void enableVAD(bool state);

        [Export("enableCNG:")]
        void enableCNG(bool state);

        [Export("sendOptions:sdp:")]
        int sendOptions(string to, string sdp);

        [Export("sendInfo:mimeType:subMimeType:infoContents:")]
        int sendInfo(nint sessionId, string mimeType, string subMimeType, string infoContents);


        [Export("sendMessage:mimeType:subMimeType:message:messageLength:")]
        nint sendMessage(nint sessionId, string mimeType, string subMimeType, NSData message, int messageLength);

        [Export("sendOutOfDialogMessage:mimeType:subMimeType:isSMS:message:messageLength:")]
        nint sendOutOfDialogMessage(string to, string mimeType,string subMimeType, bool isSMS,NSData message, int messageLength);

        [Export("presenceSubscribe:subject:")]
        nint presenceSubscribe(string contact, string subject);

        [Export("presenceTerminateSubscribe:")]
        int presenceTerminateSubscribe(nint subscribeId);

        [Export("presenceAcceptSubscribe:")]
        int presenceRejectSubscribe(nint subscribeId);

        [Export("presenceRejectSubscribe:")]
        int presenceAcceptSubscribe(nint subscribeId);

        [Export("setPresenceStatus:statusText:")]
        int setPresenceStatus(nint subscribeId, string stateText);

        [Export("sendSubscription:eventName:")]
        nint sendSubscription(string to, string eventName);

        [Export("terminateSubscription:")]
        int terminateSubscription(nint subscribeId);

        [Export("setDefaultSubscriptionTime:")]
        nint setDefaultSubscriptionTime(int secs);

        [Export("setDefaultPublicationTime:")]
        nint setDefaultPublicationTime(int secs);

        [Export("setPresenceMode:")]
        nint setPresenceMode(int mode);


        [Export("pickupBLFCall:videoCall:")]
        nint pickupBLFCall(String replaceDialogId, bool videoCall);

        [Export("audioPlayLoopbackTest:")]
        void audioPlayLoopbackTest(bool state);

        [Export("startKeepAwake")]
        bool startKeepAwake();

        [Export("stopKeepAwake")]//call in applicationWillEnterForeground
        bool stopKeepAwake();

        [Export("startAudio")]
        void startAudio();

        [Export("stopAudio")]
        void stopAudio();

        [Export("enableCallKit:")]
        int enableCallKit(bool state);
    }
}
