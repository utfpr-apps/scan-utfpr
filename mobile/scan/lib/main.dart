import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';

import 'modules/block/block_page.dart';
import 'modules/home/home_page.dart';
import 'modules/login/login_page.dart';
import 'modules/notification/notification_page.dart';
import 'modules/scanner/scanner_QR_Code_page.dart';
import 'modules/splash/splash_page.dart';
import 'modules/success/success_page.dart';
import 'shared/themes/app_colors.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        splashColor: AppColors.primary,
        primaryColor: AppColors.primary,
      ),
      localizationsDelegates: const [
        GlobalMaterialLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
      ],
      supportedLocales: [Locale('pt', 'BR')],
      initialRoute: "splash",
      routes: {
        "scanner": (context) => const QRViewExample(),
        "login": (context) => const LoginPage(),
        "splash": (context) => const SplashPage(),
        "home": (context) => HomePage(),
        "notification": (context) => const NotificationPage(),
        "success": (context) => const SuccessPage(),
        "block": (context) => const BlockPage(),
      },
    );
  }
}
