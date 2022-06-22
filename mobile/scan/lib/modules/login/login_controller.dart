import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:google_sign_in/google_sign_in.dart';

class LoginController {
  Future<void> googleSignIn(BuildContext context) async {
    
    GoogleSignIn _googleSignIn = GoogleSignIn(
     // clientId: '479882132969-9i9aqik3jfjd7qhci1nqf0bm2g71rm1u.apps.googleusercontent.com',
     clientId: '397967401753-a2325l4drfileavn0jg52kfg7v2hmk16.apps.googleusercontent.com',
      scopes: [
        'email',
        
      ],
    );
    try {
      final response = await _googleSignIn.signIn();
      print(response!.email);
      response.serverAuthCode;
      print(response.serverAuthCode);

      response.authentication.then((googleKey){
              print(googleKey.accessToken);
              print(googleKey.idToken);
              print(googleKey.idToken?.substring(1023, googleKey.idToken?.length));
              print(googleKey.idToken?.length);
                final credential = GoogleAuthProvider.credential(
    accessToken: googleKey.accessToken,
    idToken: googleKey.idToken,
  );
  print(credential.providerId);


              
              
              

              Navigator.pushNamed(context,"home");
          }).catchError((err){
            print('inner error');
          });
    } catch (error) {
      print(" O erro eh: $error");
    }
  }
}