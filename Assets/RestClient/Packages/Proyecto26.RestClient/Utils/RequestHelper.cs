using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26
{
    public class RequestHelper
    {
        private Dictionary<string, string> _headers;

        public string Uri { get; set; }

        public string Method { get; set; }

        public object Body { get; set; }

        public string BodyString { get; set; }

        public byte[] BodyRaw { get; set; }

        public int? Timeout { get; set; }

        public string ContentType { get; set; }

        public int Retries { get; set; }

        public float RetrySecondsDelay { get; set; }

        public Action<RequestException, int> RetryCallback { get; set; }

        public bool EnableDebug { get; set; }

        public bool? ChunkedTransfer { get; set; }

        public bool? UseHttpContinue { get; set; }

        public int? RedirectLimit { get; set; }

        public bool IgnoreHttpException { get; set; }

        public WWWForm FormData { get; set; }

        public Dictionary<string, string> SimpleForm { get; set; }

        public List<IMultipartFormSection> FormSections { get; set; }

        public UploadHandler UploadHandler { get; set; }

        public DownloadHandler DownloadHandler { get; set; }

        public Dictionary<string, string> Headers
        {
            get
            {
                if (_headers == null) _headers = new Dictionary<string, string>();
                return _headers;
            }
            set => _headers = value;
        }

        public float UploadProgress
        {
            get
            {
                float progress = 0;
                if (Request != null) progress = Request.uploadProgress;
                return progress;
            }
        }

        public ulong UploadedBytes
        {
            get
            {
                ulong bytes = 0;
                if (Request != null) bytes = Request.uploadedBytes;
                return bytes;
            }
        }

        public float DownloadProgress
        {
            get
            {
                float progress = 0;
                if (Request != null) progress = Request.downloadProgress;
                return progress;
            }
        }

        public ulong DownloadedBytes
        {
            get
            {
                ulong bytes = 0;
                if (Request != null) bytes = Request.downloadedBytes;
                return bytes;
            }
        }

        /// <summary>
        ///     Internal use
        /// </summary>
        public UnityWebRequest Request { private get; set; }

        public bool IsAborted { get; set; }

        /// <summary>
        ///     Get the value of a header
        /// </summary>
        /// <returns>The string value of the header.</returns>
        /// <param name="name">The name of the header.</param>
        public string GetHeader(string name)
        {
            string headerValue;
            if (Request != null)
                headerValue = Request.GetRequestHeader(name);
            else
                Headers.TryGetValue(name, out headerValue);
            return headerValue;
        }

        /// <summary>
        ///     Abort the request manually
        /// </summary>
        public void Abort()
        {
            if (Request != null && !IsAborted)
                try
                {
                    IsAborted = true;
                    Request.Abort();
                }
                finally
                {
                    Request = null;
                }
        }

#if UNITY_2018_1_OR_NEWER
        public CertificateHandler CertificateHandler { get; set; }
#endif
    }
}