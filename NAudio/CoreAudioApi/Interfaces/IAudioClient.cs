﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using NAudio.Wave;

namespace NAudio.CoreAudioApi.Interfaces
{
    /// <summary>
    /// n.b. WORK IN PROGRESS - this code will probably do nothing but crash at the moment
    /// Defined in AudioClient.h
    /// </summary>
    [Guid("1CB9AD4C-DBFA-4c32-B178-C2F568A703B2"), 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IAudioClient
    {
        int Initialize(AudioClientShareMode shareMode,
            AudioClientStreamFlags StreamFlags,
            long hnsBufferDuration, // REFERENCE_TIME
            long hnsPeriodicity, // REFERENCE_TIME
            [In] WaveFormat pFormat,
            [In] ref Guid AudioSessionGuid);

        /// <summary>
        /// The GetBufferSize method retrieves the size (maximum capacity) of the endpoint buffer.
        /// </summary>
        int GetBufferSize(out uint bufferSize);

        int GetStreamLatency(out long streamLatency);

        int GetCurrentPadding(out int currentPadding);

        int IsFormatSupported(
            AudioClientShareMode shareMode,
            [In] WaveFormatExtensible pFormat,
            out IntPtr closestMatchPointer);

        int GetMixFormat(out IntPtr deviceFormatPointer);

        // REFERENCE_TIME is 64 bit int        
        int GetDevicePeriod(out long defaultDevicePeriod, out long minimumDevicePeriod);

        int Start();

        int Stop();

        int Reset();
        
        int SetEventHandle(IntPtr eventHandle);

        int GetService(ref Guid interfaceId, [MarshalAs(UnmanagedType.IUnknown)] out object interfacePointer);
    }
}
