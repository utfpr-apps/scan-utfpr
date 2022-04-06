import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:scan/modules/notification/pages/description_page.dart';
import 'package:scan/modules/notification/pages/notificate_page.dart';
import 'package:scan/shared/widgets/button.dart';

import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_text_styles.dart';

class NotificationPage extends StatefulWidget {
  const NotificationPage({Key? key}) : super(key: key);

  @override
  State<NotificationPage> createState() => _NotificationPageState();
}

class _NotificationPageState extends State<NotificationPage> {
  int index = 0;
  @override
  Widget build(BuildContext context) {
    List<Widget> FluxoPage = [
      DescriptionPage(
        buttonChild: Button(
          title: "Notificar UTFPR",
          onTap: () {
            setState(() {
              index++;
            });
          },
        ),
      ),
      NotificatePage(buttonChild: Button(
          title: "Confirmar data do exame",
          onTap: () {
            setState(() {
              
            });
          },
        ),
      ),
    ];
    return Scaffold(
      appBar: AppBar(
        backgroundColor: AppColors.primary,
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 25),
        child: Expanded(child: FluxoPage[index]),
      ),
    );
  }
}
