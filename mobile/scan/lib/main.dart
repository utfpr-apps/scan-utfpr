import 'package:flutter/material.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:scan/modules/block/block_page.dart';
import 'package:scan/modules/home/home_page.dart';
import 'package:scan/modules/splash/splash_page.dart';
import 'package:scan/modules/success/success_page.dart';
import 'package:scan/shared/themes/app_colors.dart';

import 'modules/notification/notification_page.dart';

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
      supportedLocales: [const Locale('pt', 'BR')],
      initialRoute: "home",
      routes: {
        "splash": (context) => SplashPage(),
        "home": (context) => HomePage(),
        "notification": (context) => NotificationPage(),
        "success": (context) => SuccessPage(),
        "block": (context) => BlockPage(),
      },
    );
  }
}
