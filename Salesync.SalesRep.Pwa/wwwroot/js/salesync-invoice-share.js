window.salesyncInvoiceShare = {
    shareReceipt: async function (selector, fileName, fallbackText) {
        const receiptElement = document.querySelector(selector);

        if (!receiptElement || typeof html2canvas === "undefined") {
            const whatsappUrl =
                "https://wa.me/?text=" + encodeURIComponent(fallbackText || "");

            window.open(whatsappUrl, "_blank");
            return;
        }

        const canvas = await html2canvas(receiptElement, {
            backgroundColor: "#ffffff",
            scale: 2,
            useCORS: true
        });

        const blob = await new Promise(resolve =>
            canvas.toBlob(resolve, "image/png")
        );

        if (!blob) {
            const whatsappUrl =
                "https://wa.me/?text=" + encodeURIComponent(fallbackText || "");

            window.open(whatsappUrl, "_blank");
            return;
        }

        const safeFileName = fileName || "salesync-invoice.png";

        const file = new File(
            [blob],
            safeFileName,
            { type: "image/png" }
        );

        if (navigator.canShare && navigator.canShare({ files: [file] })) {
            await navigator.share({
                title: "فاتورة Salesync",
                text: "فاتورة Salesync",
                files: [file]
            });

            return;
        }

        const imageUrl = URL.createObjectURL(blob);

        const link = document.createElement("a");
        link.href = imageUrl;
        link.download = safeFileName;
        link.click();

        URL.revokeObjectURL(imageUrl);

        const whatsappUrl =
            "https://wa.me/?text=" + encodeURIComponent(fallbackText || "");

        window.open(whatsappUrl, "_blank");
    }
};