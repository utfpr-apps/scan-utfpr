import 'dart:convert';

import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:google_sign_in/google_sign_in.dart';
import 'package:scan/Api/Api.dart';
import 'package:scan/globals.dart' as globals;
import 'package:scan/models/login_model.dart';
import 'package:scan/models/response_api_user_model.dart';


class LoginController {
  Future<void> googleSignIn(BuildContext context) async {
    API _api = API();
    GoogleSignIn _googleSignIn = GoogleSignIn(
      // clientId: '479882132969-9i9aqik3jfjd7qhci1nqf0bm2g71rm1u.apps.googleusercontent.com',
      clientId:
          '397967401753-f9h43hidd75m1f2pn32da39rien6ojbv.apps.googleusercontent.com',
      scopes: [
        'email',
      ],
    );
    try {
      final response = await _googleSignIn.signIn();
      print(response!.email);
      response.serverAuthCode;


      response.authentication.then((googleKey) {

        print(googleKey.idToken);
        print(googleKey.idToken?.substring(1023, googleKey.idToken?.length));

        final credential = GoogleAuthProvider.credential(
          accessToken: googleKey.accessToken,
          idToken: googleKey.idToken,
        );

        _api
            .login(
                LoginModel(provider: "google.com", token: googleKey.idToken!))
            .then((value) async {
              ResponseAPIUserModel _responseAPIUserModel = ResponseAPIUserModel();
              
              _responseAPIUserModel = ResponseAPIUserModel.fromMap(await json.decode(value.body));
              globals.token = _responseAPIUserModel.userDataViewModel!.token!;
              print(globals.token);
          if (value.statusCode == 200) Navigator.pushNamed(context, "home");
        });
        print(credential.providerId);
      }).catchError((e) {
        print('Erro: $e');
      });
    } catch (error) {
      print(" O erro eh: $error");
    }
  }
}
