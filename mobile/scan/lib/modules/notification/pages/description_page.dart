import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../../../shared/themes/app_text_styles.dart';
import '../../../shared/widgets/button.dart';

class DescriptionPage extends StatefulWidget {
  final Widget buttonChild;
  const DescriptionPage({Key? key, required this.buttonChild})
      : super(key: key);

  @override
  State<DescriptionPage> createState() => _DescriptionPageState();
}

class _DescriptionPageState extends State<DescriptionPage> {
  DateTime? _chosenDateTime;
  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.spaceAround,
      crossAxisAlignment: CrossAxisAlignment.center,
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
          "Você foi diagnosticado com COVID-19 recentemente?",
          textAlign: TextAlign.center,
          style: AppTextStyles.normalRegular,
        ),
        Text(
          "Notificar a universidade é uma grande ação para proteger os demais alunos e professores.",
          textAlign: TextAlign.center,
          style: AppTextStyles.normalRegular,
        ),
        widget.buttonChild,
      ],
    );
  }
}
