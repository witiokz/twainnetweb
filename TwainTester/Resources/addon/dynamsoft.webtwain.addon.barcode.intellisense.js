/*!
* Dynamsoft JavaScript Library
/*!
* Dynamsoft WebTwain Addon Barcode JavaScript Intellisense
* Product: Dynamsoft Web Twain Addon
* Web Site: http://www.dynamsoft.com
*
* Copyright 2015, Dynamsoft Corporation 
* Author: Dynamsoft Support Team
* Version: 10.2.0.324
*/

/// this barcode format is different with twain defined
var EnumDWT_BarcodeFormat = {
    CODE_39: 4,
    CODE_128: 16
};

var Barcode = {};
WebTwainAddon.Barcode = Barcode;

Barcode.Download = function(remoteFile, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
    /// <summary> Download and install barcode add-on on the local system. </summary>
    /// <param name="remoteFile" type="string">specifies the value of which frame to get. The index is 0-based.</param>
    /// <param name="optionalAsyncSuccessFunc" type="function">optional. The function to call when the upload succeeds. Please refer to the function prototype OnSuccess.</param>
    /// <param name="optionalAsyncFailureFunc" type="function">optional. The function to call when the upload fails. Please refer to the function prototype OnFailure.</param>
    /// <returns type="bool"></returns>   
};

Barcode.Read = function(sImageIndex, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
    /// <summary> Read barcode on a specified image loaded in Dynamic Web TWAIN. </summary>
    /// <param name="sImageIndex" type="short">Specifies the index of the image.</param>
    /// <param name="format" type="EnumDWT_BarcodeFormat">Specifies the barcode format.</param>
    /// <param name="optionalAsyncSuccessFunc" type="function">optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.</param>
    /// <param name="optionalAsyncFailureFunc" type="function">optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.</param>
    /// <returns type="bool"></returns>   
};

Barcode.ReadRect = function(sImageIndex, left, top, right, bottom, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
    /// <summary> Read barcode on a specified image loaded in Dynamic Web TWAIN. </summary>
    /// <param name="sImageIndex" type="short">Specifies the index of the image.</param>
    /// <param name="left" type="int">specifies the x-coordinate of the upper-left corner of the rectangle.</param>
    /// <param name="top" type="int">specifies the y-coordinate of the upper-left corner of the rectangle.</param>
    /// <param name="right" type="int">specifies the x-coordinate of the lower-right corner of the rectangle.</param>
    /// <param name="bottom" type="int">specifies the y-coordinate of the lower-right corner of the rectangle.</param>
    /// <param name="format" type="EnumDWT_BarcodeFormat">Specifies the barcode format.</param>
    /// <param name="optionalAsyncSuccessFunc" type="function">optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.</param>
    /// <param name="optionalAsyncFailureFunc" type="function">optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.</param>
    /// <returns type="bool"></returns>   
};


