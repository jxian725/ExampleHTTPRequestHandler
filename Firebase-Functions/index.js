'use strict';

const functions = require('firebase-functions');
const admin = require('firebase-admin');
const handlebars = require('handlebars');
const fs = require('fs');
const path = require('path');


admin.initializeApp();
/////////////////////// HTTP REQUEST HANDLER///////////////////////////
exports.activationkey = functions.region('asia-southeast2').https.onRequest((request,response)=> {
	//Retrieve Key
	var db = admin.database();
	var ref = db.ref("/product/csgo/activationkey");
	var actualkey; 
	ref.on("value", function(snapshot) {
		actualkey = snapshot.val()
  console.log(actualkey);
}, function (errorObject) {
  console.log("The read failed: " + errorObject.code);
});
	var keyreceived = request.query.key;
	var respondmessage;
	var newkey;
	if (keyreceived === actualkey){
		respondmessage = "true";
		newkey = GenerateSerialNumber("0000-0000-0000-0000");
		//Update Key
		let userRef = db.ref('/product');
		userRef.child('csgo').update({activationkey: newkey})
	} else {
		respondmessage = "false";
	}
	//Response Http 
	response.send(respondmessage);
	
	//Generate New Key
	function GenerateRandomNumber(min,max){
	return Math.floor(Math.random() * (max - min + 1)) + min;
	}
	function GenerateRandomChar() {
	var chars = "ABCDEFGJKLMNPQRSTUVWXYZ123456789";
	var randomNumber = GenerateRandomNumber(0,chars.length - 1);
	return chars[randomNumber];
	}
	function GenerateSerialNumber(mask){
	var serialNumber = "";
	if(mask !== null){
		for(var i=0; i < mask.length; i++){
			var maskChar = mask[i];
			serialNumber += maskChar === "0" ? GenerateRandomChar() : maskChar;
		}
	}
	return serialNumber;
	}
});