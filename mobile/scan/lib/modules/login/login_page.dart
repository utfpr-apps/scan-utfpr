import 'dart:ffi';

import 'package:flutter/material.dart';
import 'package:scan/modules/login/login_controller.dart';
import 'package:scan/shared/themes/app_text_styles.dart';
import 'package:scan/shared/widgets/social_button.dart';

//https://petercoding.com/firebase/2021/05/24/using-google-sign-in-with-firebase-in-flutter/

class LoginPage extends StatelessWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    double withOfScreen = MediaQuery.of(context).size.width;
    return Scaffold(
      body: SafeArea(
        child: Container(

          child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 15, vertical: 100),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Align(
                  child: Image.asset("assets/images/others/login.png"),
                ),
                Text(
                  "Bem-vindo (a) ao \nScan UTFPR",
                  style: AppTextStyles.normalRegular,
                  textAlign: TextAlign.center,
                ),
                SocialLoginButton(onTap: () {
                  LoginController _loginController = LoginController();
                  _loginController.googleSignIn(context);
                  
                }),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
