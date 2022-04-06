import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../../shared/themes/app_text_styles.dart';
import '../../../shared/widgets/button.dart';

class NotificatePage extends StatefulWidget {
  final Widget buttonChild;
  const NotificatePage({Key? key, required this.buttonChild}) : super(key: key);

  @override
  State<NotificatePage> createState() => _NotificatePageState();
}

class _NotificatePageState extends State<NotificatePage> {
  DateTime? _chosenDateTime;
  @override
  Widget build(BuildContext context) {
    return Column(
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
            use24hFormat: true,
            initialDateTime: DateTime.now(),
            onDateTimeChanged: (val) {
              setState(
                () {
                  _chosenDateTime = val;
                },
              );
            },
          ),
        ),
        widget.buttonChild,
      ],
    );
  }
}
