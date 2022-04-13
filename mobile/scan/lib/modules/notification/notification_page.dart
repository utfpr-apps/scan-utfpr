import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:scan/modules/notification/pages/add_exame_page.dart';
import 'package:scan/modules/notification/pages/description_page.dart';
import 'package:scan/modules/notification/pages/notificate_page.dart';
import 'package:scan/shared/widgets/button.dart';

import '../../shared/themes/app_colors.dart';
import '../../shared/themes/app_images.dart';
import '../../shared/themes/app_text_styles.dart';
import '../../shared/widgets/drawer_tiles.dart';

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
      NotificatePage(
        buttonChild: Button(
          title: "Confirmar data do exame",
          onTap: () {
            setState(() {
              index++;
            });
          },
        ),
      ),
      AddExamePage(
        buttonChild: Column(
          children: [
            Button(
              title: "Enviar exame",
              onTap: () {
                setState(() {
                  Navigator.pushNamed(context, "success");
                });
              },
            ),
            TextButton(
              onPressed: () {
                Navigator.pushNamed(context, "home");
              },
              child: const Text(
                "Não tenho no momento",
                style: TextStyle(
                  color: AppColors.darkGray,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
          ],
        ),
      ),
    ];
    return Scaffold(
      appBar: AppBar(
        backgroundColor: AppColors.primary,
      ),
      drawer: Drawer(
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 60, vertical: 25),
              child: Image.asset(
                AppImages.logoUTFPR,
                fit: BoxFit.fitHeight,
              ),
            ),
            Container(
              height: 1,
              color: Colors.grey.shade300,
            ),
            DrawerTiles(
              imageAssetSouce: AppImages.qrCode,
              text: "Ler QR Code",
              ontap: () {
                Navigator.pushNamed(context, "scanner");
              },
            ),
            DrawerTiles(
              isSelected: true,
              imageAssetSouce: AppImages.destaque,
              text: "Notificar COVID-19",
              ontap: () {
                Navigator.pushNamed(context, "notification");
              },
            ),
            DrawerTiles(
              imageAssetSouce: AppImages.download,
              text: "Sair do app",
              ontap: () {
                SystemNavigator.pop();
              },
            ),
          ],
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 25),
        child: Expanded(child: FluxoPage[index]),
      ),
    );
  }
}
