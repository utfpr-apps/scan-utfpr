import 'package:animated_card/animated_card.dart';
import 'package:flutter/material.dart';
import 'package:lottie/lottie.dart';
import 'package:scan/shared/themes/app_text_styles.dart';

class SplashPage extends StatefulWidget {
  const SplashPage({Key? key}) : super(key: key);

  @override
  State<SplashPage> createState() => _SplashPageState();
}

class _SplashPageState extends State<SplashPage> {
  double tamanho = 0;
  @override
  late AnimationController controller;
  late Animation<double> animation;

  initState() {
    setState(() {});
    super.initState();
  }

  Widget build(BuildContext context) {
    Widget teste() {
      Future.delayed(
        Duration(milliseconds: 6400),
        () {
          Navigator.pushReplacementNamed(context, "home");
        },
      );
      return Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Lottie.asset("assets/anim/splash.json"),
            Center(
              child: Text(
                "SCAN",
                style: AppTextStyles.splashTittle,
              ),
            ),
          ],
        ),
      );
    }

    return Scaffold(body: teste());
  }
}
