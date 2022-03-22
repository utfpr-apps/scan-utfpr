import 'package:check/shared/themes/app_text_styles.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../shared/themes/app_colors.dart';

class NotificationPage extends StatefulWidget {
  const NotificationPage({Key? key}) : super(key: key);

  @override
  State<NotificationPage> createState() => _NotificationPageState();
}

class _NotificationPageState extends State<NotificationPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: AppColors.primary,
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          Center(
            child: RichText(
              textAlign: TextAlign.center,
              text: TextSpan(
                style: AppTextStyles.normalRegular,
                text: "Notificar a ",
                children: [
                  TextSpan(text: "UTFPR", style: AppTextStyles.normalBold),
                ],
              ),
            ),
          ),
          Text(
            "Qual a data do exame/diagnóstico?",
            style: AppTextStyles.normalRegular,
          ),
          Container(
            height: 200,
            child: CupertinoDatePicker(
              initialDateTime: DateTime.now(),
              onDateTimeChanged: (data) {},
            ),
          ),
          ElevatedButton(
            onPressed: () {},
            child: Container(
              child: const Text(
                "Ler o QR Code",
                textAlign: TextAlign.center,
              ),
              width: 300,
            ),
          ),
        ],
      ),
    );
  }
}
