import 'package:flutter/material.dart';
import 'package:lottie/lottie.dart';
import 'package:scan/shared/themes/app_text_styles.dart';

class SplashPage extends StatelessWidget {
  const SplashPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Widget teste() {
      Future.delayed(
        Duration(milliseconds: 6400),
        () {
          Navigator.pushReplacementNamed(context, "home");
        },
      );
      return Center(
        child: Lottie.asset("assets/anim/splash.json"),
      );
    }

    return Scaffold(body: teste());
  }
}
