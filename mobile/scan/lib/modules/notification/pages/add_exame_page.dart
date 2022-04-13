import 'package:flutter/material.dart';

import '../../../shared/themes/app_text_styles.dart';

class AddExamePage extends StatefulWidget {
  final Widget buttonChild;
  const AddExamePage({ Key? key, required this.buttonChild }) : super(key: key);

  @override
  State<AddExamePage> createState() => _AddExamePageState();
}

class _AddExamePageState extends State<AddExamePage> {
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
          "Você possui o exame com o diagnóstico?",
          textAlign: TextAlign.center,
          style: AppTextStyles.normalRegular,
        ),
        Text(
          "Envie-nos uma foto ou o arquivo do exame realizado.",
          textAlign: TextAlign.center,
          style: AppTextStyles.normalRegular,
        ),
        Text(
          "Tenha cuidado para que todas as informações fiquem bem legíveis",
          textAlign: TextAlign.center,
          style: AppTextStyles.normalRegular,
        ),
        widget.buttonChild,
      ],
    );
  }
}
