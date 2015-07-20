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

/** this barcode format is different with twain defined */
var EnumDWT_BarcodeFormat = {
    CODE_39: 4,
    CODE_128: 16
};

var Barcode = {};
WebTwainAddon.Barcode = Barcode;

/**
 *  Download and install barcode add-on on the local system. 
 * @method Dynamsoft.WebTwain#Download 
 * @param {string} remoteFile specifies the value of which frame to get. The index is 0-based.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when the upload succeeds. Please refer to the function prototype OnSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when the upload fails. Please refer to the function prototype OnFailure.
 * @return {bool}
 */
Barcode.Download = function(remoteFile, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};

/**
 *  Read barcode on a specified image loaded in Dynamic Web TWAIN. 
 * @method Dynamsoft.WebTwain#Read 
 * @param {short} sImageIndex Specifies the index of the image.
 * @param {EnumDWT_BarcodeFormat} format Specifies the barcode format.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.
 * @return {bool}
 */
Barcode.Read = function(sImageIndex, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};

/**
 *  Read barcode on a specified image loaded in Dynamic Web TWAIN. 
 * @method Dynamsoft.WebTwain#ReadRect 
 * @param {short} sImageIndex Specifies the index of the image.
 * @param {int} left specifies the x-coordinate of the upper-left corner of the rectangle.
 * @param {int} top specifies the y-coordinate of the upper-left corner of the rectangle.
 * @param {int} right specifies the x-coordinate of the lower-right corner of the rectangle.
 * @param {int} bottom specifies the y-coordinate of the lower-right corner of the rectangle.
 * @param {EnumDWT_BarcodeFormat} format Specifies the barcode format.
 * @param {function} optionalAsyncSuccessFunc optional. The function to call when barcode reading succeeds. Please refer to the function prototype OnBarcodeReadSuccess.
 * @param {function} optionalAsyncFailureFunc optional. The function to call when barcode reading fails. Please refer to the function prototype OnBarcodeReadFailure.
 * @return {bool}
 */
Barcode.ReadRect = function(sImageIndex, left, top, right, bottom, format, optionalAsyncSuccessFunc, optionalAsyncFailureFunc) {
};



